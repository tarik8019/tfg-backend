using ApiRest.Models.DTOs.TurnoDTOs;

namespace ApiRest.Models.DTOs.AsignacionTurnoDTOs
{
    public class AsignacionTurnoDTO
    {

        public int IdAsignacion { get; set; }
        public int IdTurno { get; set; }
        public int IdEmpleado { get; set; } 
        public string Estado { get; set; } = null!;
        public TurnoDTO Turno { get; set; } = null!;
    }
}
