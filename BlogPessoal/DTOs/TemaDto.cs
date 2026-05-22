using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.DTOs;

public class TemaDto
{
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Descricao { get; set; } = string.Empty;
}