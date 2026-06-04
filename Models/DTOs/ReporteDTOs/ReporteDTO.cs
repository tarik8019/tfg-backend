namespace ApiRest.Models.DTOs.ReporteDTOs
{
    public class ReporteDTO
    {

        public int IdReporte { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime FechaGeneracion { get; set; }
        public string ArchivoUrl { get; set; } = string.Empty;
    }
}
