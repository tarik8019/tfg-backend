using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.NotificacionDTOs
{
    public class CreateNotificacionDTO
    {

        [Required]
        public int IdUsuario { get; set; }

        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Mensaje { get; set; } = string.Empty;

        public TipoNotificacion Tipo { get; set; } 

        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        public EstadoNotificacion Estado { get; set; }
    }
}
