namespace IndicadoresWeb.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UnidadMedicion
{
    [Key] // Indica que es la clave primaria
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental (IDENTITY)
    public int Id { get; set; }

    [Required] // No permite NULL (es obligatorio)
    [MaxLength(200)] 
    public string Descripcion { get; set; }
}