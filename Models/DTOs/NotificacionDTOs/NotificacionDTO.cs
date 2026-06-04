namespace ApiRest.Models.DTOs.NotificacionDTOs
{
    public class NotificacionDTO
    {

        public int IdNotificacion { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
