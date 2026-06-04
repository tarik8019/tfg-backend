using ApiRest.Models.DTOs.SedeDTOs;
using ApiRest.Utils.Enum;

namespace ApiRest.Models.DTOs.TurnoDTOs
{
    public class TurnoDTO
    {

        public int IdTurno { get; set; }
        public int IdSede { get; set; }

        public SedeDTO? Sede { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public TipoTurno Nombre { get; set; } 

        public bool esNocturno { get; set; }    
    }
}
