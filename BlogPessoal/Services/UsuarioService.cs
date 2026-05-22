using BlogPessoal.DTOs;
using BlogPessoal.Models;
using BlogPessoal.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BlogPessoal.Services;

public class UsuarioService
{
	private readonly IUsuarioRepository _repository;
	private readonly PasswordHasher<Usuario> _hasher;

	public UsuarioService(IUsuarioRepository repository)
	{
		_repository = repository;
		_hasher = new PasswordHasher<Usuario>();
	}

	public async Task<IEnumerable<Usuario>> GetAllAsync()
	{
		return await _repository.GetAllAsync();
	}

	public async Task<Usuario?> GetByIdAsync(long id)
	{
		return await _repository.GetByIdAsync(id);
	}

	public async Task<Usuario?> CreateAsync(UsuarioDto dto)
	{
		var existe = await _repository.GetByEmailAsync(dto.Email);
		if (existe != null) return null;

		var usuario = new Usuario
		{
			Nome = dto.Nome,
			Email = dto.Email,
			Foto = dto.Foto
		};

		usuario.Senha = _hasher.HashPassword(usuario, dto.Senha);
		return await _repository.CreateAsync(usuario);
	}

	public async Task<Usuario?> UpdateAsync(long id, UsuarioDto dto)
	{
		var usuario = await _repository.GetByIdAsync(id);
		if (usuario == null) return null;

		usuario.Nome = dto.Nome;
		usuario.Email = dto.Email;
		usuario.Foto = dto.Foto;
		usuario.Senha = _hasher.HashPassword(usuario, dto.Senha);

		return await _repository.UpdateAsync(usuario);
	}

	public async Task<bool> DeleteAsync(long id)
	{
		var usuario = await _repository.GetByIdAsync(id);
		if (usuario == null) return false;

		await _repository.DeleteAsync(id);
		return true;
	}

	public async Task<Usuario?> AutenticarAsync(UsuarioLogin login)
	{
		var usuario = await _repository.GetByEmailAsync(login.Email);
		if (usuario == null) return null;

		var resultado = _hasher.VerifyHashedPassword(usuario, usuario.Senha, login.Senha);
		return resultado == PasswordVerificationResult.Success ? usuario : null;
	}
}