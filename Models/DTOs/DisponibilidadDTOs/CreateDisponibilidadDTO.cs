using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.DisponibilidadDTOs
{
    public class CreateDisponibilidadDTO
    {

        [Required]
        public int IdEmpleado { get; set; }

        public DiaSemana DiaSemana { get; set; } 

        public TimeSpan HoraInicio { get; set; } 
        public TimeSpan HoraFin { get; set; }
    }
}
