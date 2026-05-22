using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPessoal.Models;

public class Postagem
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }

	[Required]
	[StringLength(255)]
	public string Titulo { get; set; } = string.Empty;

	[Required]
	[StringLength(10000)]
	public string Texto { get; set; } = string.Empty;

	public DateTime Data { get; set; } = DateTime.UtcNow;

	public Tema? Tema { get; set; }
	public long? TemaId { get; set; }

	public Usuario? Usuario { get; set; }
	public long? UsuarioId { get; set; }
}