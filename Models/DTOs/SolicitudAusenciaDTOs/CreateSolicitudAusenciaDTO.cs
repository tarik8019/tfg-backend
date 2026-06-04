using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.SolicitudAusenciaDTOs
{
    public class CreateSolicitudAusenciaDTO
    {

        [Required]
        public int IdEmpleado { get; set; }

        [Required]
        public TipoAusencia Tipo { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [MaxLength(255)]
        public string DocumentoJustificante { get; set; } = string.Empty;
    }
}
