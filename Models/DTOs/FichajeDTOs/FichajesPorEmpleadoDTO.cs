namespace ApiRest.Models.DTOs.FichajeDTOs
{
    public class FichajesPorEmpleadoDTO
    {


        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public List<FichajeDTO> Fichajes { get; set; } = new List<FichajeDTO>();
    }
}
