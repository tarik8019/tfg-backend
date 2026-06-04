using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.TurnoDTOs
{
    public class CreateTurnoDTO
    {

        [Required]
        public int IdSede { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }


        [Required]
        public bool esNocturno { get; set; }
    }
}
