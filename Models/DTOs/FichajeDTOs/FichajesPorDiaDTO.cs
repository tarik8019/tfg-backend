namespace ApiRest.Models.DTOs.FichajeDTOs
{
    public class FichajesPorDiaDTO
    {
        public DateTime Fecha { get; set; }
        public List<FichajesPorEmpleadoDTO> Empleados { get; set; } = new();
    }
}
