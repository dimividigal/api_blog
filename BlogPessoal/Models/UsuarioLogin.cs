using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.Models;

public class UsuarioLogin
{
    [Required]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Senha { get; set; } = string.Empty;
}