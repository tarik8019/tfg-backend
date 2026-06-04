using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class SolicitudAusenciaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSolicitud { get; set; }

        [Required]
        public TipoAusencia TipoAusencia { get; set; }

        //el primer día en el que el empleado estará ausente.
        [Required]
        public DateTime FechaInicio { get; set; }

        // Indica el último día de la ausencia.
        [Required]
        public DateTime FechaFin { get; set; }

     
        [Required]
        public EstadoSolicitudAusencia EstadoSolicitudAusencia { get; set; } 

        [MaxLength(255)]
        public string DocumentoJustificante { get; set; } = string.Empty;

        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")]
        public EmpleadoEntity Empleado { get; set; } = null!;
    }
}
