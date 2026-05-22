using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.DTOs;

public class UsuarioDto
{
	public long Id { get; set; }

	[Required]
	[StringLength(255)]
	public string Nome { get; set; } = string.Empty;

	[Required]
	[StringLength(255)]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	[Required]
	[StringLength(255)]
	public string Senha { get; set; } = string.Empty;

	[StringLength(5000)]
	public string? Foto { get; set; }
}