namespace ApiRest.Models.DTOs.SedeDTOs
{
    public class SedeDTO
    {

        public int IdSede { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int RadioGeofencing { get; set; }
    }
}
