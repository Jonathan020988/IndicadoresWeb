namespace IndicadoresWeb.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Seccion
{
    [Key] // Clave primaria
    [Required] // No permite NULL
    [MaxLength(2)] 
    public string Id { get; set; }

    [Required] // No permite NULL
    [MaxLength(200)] 
    public string Nombre { get; set; }
}