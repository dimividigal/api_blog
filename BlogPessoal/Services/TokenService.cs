using BlogPessoal.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogPessoal.Services;

public class TokenService
{
	private readonly IConfiguration _configuration;

	public TokenService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GerarToken(Usuario usuario)
	{
		var claims = new[]
		{
			new Claim(ClaimTypes.Name, usuario.Email),
			new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
		};

		var key = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var expiracao = DateTime.UtcNow.AddHours(
			int.Parse(_configuration["Jwt:ExpiresInHours"]!));

		var token = new JwtSecurityToken(
			issuer: _configuration["Jwt:Issuer"],
			audience: _configuration["Jwt:Audience"],
			claims: claims,
			expires: expiracao,
			signingCredentials: creds
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}