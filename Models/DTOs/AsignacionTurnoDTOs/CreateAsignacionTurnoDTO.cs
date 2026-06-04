using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.AsignacionTurnoDTOs
{
    public class CreateAsignacionTurnoDTO
    {
        [Required]
        public int IdTurno { get; set; }

        [Required]
        public List<int> IdEmpleados { get; set; } = [];

        [Required]
        public EstadoAsignacionTurno Estado { get; set; }
    }
}
