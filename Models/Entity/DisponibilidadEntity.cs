using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class DisponibilidadEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDisponibilidad { get; set; }

        // FK hacia Empleado
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")]
        public EmpleadoEntity Empleado { get; set; } = null!;

        [Required]
        public DiaSemana DiaSemana { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }
    }
}
