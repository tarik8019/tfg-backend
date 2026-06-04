namespace ApiRest.Models.DTOs.FichajeDTOs
{
    public class FichajeDTO
    {

        public int IdFichaje { get; set; }
        public int IdEmpleado { get; set; }
        public string TipoFichaje { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public bool ValidadoFacial { get; set; }
        public string FuenteFichaje { get; set; } = string.Empty;
    }
}
