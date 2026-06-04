namespace ApiRest.Models.DTOs.SolicitudAusenciaDTOs
{
    public class SolicitudAusenciaDTO
    {

        public int IdSolicitud { get; set; }
        public int IdEmpleado { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty; // pendiente, aprobada, rechazada
        public string DocumentoJustificante { get; set; } = string.Empty;
    }
}
