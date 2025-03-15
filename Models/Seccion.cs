// Archivo creado, pendiente de contenido.

namespace IndicadoresWeb.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Seccion
{
    [Key] // Clave primaria
    [Required] // No permite NULL
    [MaxLength(2)] // VARCHAR(2) en SQL Server
    public string Id { get; set; }

    [Required] // No permite NULL
    [MaxLength(200)] // VARCHAR(200) en SQL Server
    public string Nombre { get; set; }
}