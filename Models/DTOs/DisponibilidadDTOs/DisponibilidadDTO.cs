namespace ApiRest.Models.DTOs.DisponibilidadDTOs
{
    public class DisponibilidadDTO
    {
        public int IdDisponibilidad { get; set; }
        public int IdEmpleado { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
