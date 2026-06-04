using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.ReporteDTOs
{
    public class CreateReporteDTO
    {

        [Required]
        public TipoReporte Tipo { get; set; }
        public DateTime FechaGeneracion { get; set; } = DateTime.Now;

        [MaxLength(255)]
        public string ArchivoUrl { get; set; } = string.Empty;
    }
}
