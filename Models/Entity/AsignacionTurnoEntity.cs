using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class AsignacionTurnoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAsignacion { get; set; }

        public int IdTurno { get; set; }

        [ForeignKey("IdTurno")]
        public TurnoEntity Turno { get; set; } = null!;

        public int IdEmpleado { get; set; }

        [ForeignKey("IdEmpleado")]
        public EmpleadoEntity Empleado { get; set; } = null!;

        [Required]
        public EstadoAsignacionTurno Estado { get; set; }  


    }
}
