using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Subseccion
{
    [Key] // Clave primaria
    [Required] // No permite NULL
    [MaxLength(2)] // VARCHAR(2) en SQL Server
    public string Id { get; set; }

    [Required] // No permite NULL
    [MaxLength(100)] // VARCHAR(200) en SQL Server
    public string Nombre { get; set; }
}