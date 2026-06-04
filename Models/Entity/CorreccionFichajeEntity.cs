using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class CorreccionFichajeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCorreccion { get; set; }

        // FK hacia Empleado
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")]
        public EmpleadoEntity Empleado { get; set; } = null!;

        // FK hacia Fichaje
        public int IdFichaje { get; set; }
        [ForeignKey("IdFichaje")]
        public FichajeEntity Fichaje { get; set; } = null!;

        [Required, MaxLength(255)]
        public string Motivo { get; set; } = string.Empty;

        [Required]
        public EstadoCorreccionFichaje EstadoCorreccionFichaje { get; set; } // pendiente, aprobado, rechazado
    }
}
