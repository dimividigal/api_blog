using BlogPessoal.Models;
using BlogPessoal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.Controllers;

[ApiController]
[Route("api/usuarios")]
public class AuthController : ControllerBase
{
    private readonly UsuarioService _usuarioService;
    private readonly TokenService _tokenService;

    public AuthController(UsuarioService usuarioService, TokenService tokenService)
    {
        _usuarioService = usuarioService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLogin login)
    {
        var usuario = await _usuarioService.AutenticarAsync(login);
        if (usuario == null)
            return Unauthorized("Email ou senha inválidos.");

        var token = _tokenService.GerarToken(usuario);

        return Ok(new
        {
            id = usuario.Id,
            nome = usuario.Nome,
            email = usuario.Email,
            foto = usuario.Foto,
            token = token
        });
    }
}