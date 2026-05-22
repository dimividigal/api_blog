using BlogPessoal.DTOs;
using BlogPessoal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.Controllers;

[ApiController]
[Route("api/postagens")]
[Authorize]
public class PostagemController : ControllerBase
{
    private readonly PostagemService _service;

    public PostagemController(PostagemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var postagens = await _service.GetAllAsync();
        return Ok(postagens);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var postagem = await _service.GetByIdAsync(id);
        if (postagem == null) return NotFound();
        return Ok(postagem);
    }

    [HttpGet("filtro")]
    public async Task<IActionResult> GetByFiltro([FromQuery] long? autor, [FromQuery] long? tema)
    {
        if (autor.HasValue)
        {
            var postagens = await _service.GetByUsuarioAsync(autor.Value);
            return Ok(postagens);
        }

        if (tema.HasValue)
        {
            var postagens = await _service.GetByTemaAsync(tema.Value);
            return Ok(postagens);
        }

        return BadRequest("Informe ao menos um filtro: autor ou tema.");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostagemDto dto)
    {
        var postagem = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = postagem.Id }, postagem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] PostagemDto dto)
    {
        var postagem = await _service.UpdateAsync(id, dto);
        if (postagem == null) return NotFound();
        return Ok(postagem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}