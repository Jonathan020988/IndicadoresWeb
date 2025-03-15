namespace IndicadoresWeb.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Frecuencia
{
    [Key] // Indica que es la clave primaria
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental (IDENTITY)
    public int Id { get; set; }

    [Required] // No permite NULL (es obligatorio)
    [MaxLength(200)] // Ajusta este valor según el tamaño de tu VARCHAR
    public string Nombre { get; set; }
}
