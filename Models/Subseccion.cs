namespace IndicadoresWeb.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Subseccion
{
    [Key] // Clave primaria
    [Required] // No permite NULL
    [MaxLength(2)]
    public string Id { get; set; }

    [Required] // No permite NULL
    [MaxLength(100)] 
    public string Nombre { get; set; }
}