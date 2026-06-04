using ApiRest.Models.DTOs.TurnoDTOs;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.AsignacionTurnoDTOs
{
    public class AsignacionTurnoUpdateDTO
    {
        public int IdAsignacion { get; set; }
        public int IdTurno { get; set; }
        public List<int> IdEmpleados { get; set; } = new List<int>();
        public string Estado { get; set; } = null!;

    }
}
