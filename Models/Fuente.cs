// Archivo creado, pendiente de contenido.


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Fuente
{
    [Key] // Indica que es la clave primaria
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental (IDENTITY)
    public int Id { get; set; }

    [Required] // No permite NULL (es obligatorio)
    [MaxLength(200)] // Ajustar este valor
    public string Nombre { get; set; }
}
