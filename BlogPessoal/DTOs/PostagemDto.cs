using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.DTOs;

public class PostagemDto
{
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(10000)]
    public string Texto { get; set; } = string.Empty;

    public DateTime Data { get; set; }

    public long? TemaId { get; set; }

    public long? UsuarioId { get; set; }
}