using BlogPessoal.DTOs;
using BlogPessoal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.Controllers;

[ApiController]
[Route("api/temas")]
[Authorize]
public class TemaController : ControllerBase
{
    private readonly TemaService _service;

    public TemaController(TemaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var temas = await _service.GetAllAsync();
        return Ok(temas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var tema = await _service.GetByIdAsync(id);
        if (tema == null) return NotFound();
        return Ok(tema);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TemaDto dto)
    {
        var tema = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = tema.Id }, tema);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] TemaDto dto)
    {
        var tema = await _service.UpdateAsync(id, dto);
        if (tema == null) return NotFound();
        return Ok(tema);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}