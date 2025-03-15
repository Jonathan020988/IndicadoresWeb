namespace IndicadoresWeb.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    [Key] // Indica que es la clave primaria
    [Required] // No permite NULL
    [MaxLength(100)] 
    public string Email { get; set; }

    [Required] // No permite NULL
    [MaxLength(100)]
    public string Contraseña { get; set; }
}