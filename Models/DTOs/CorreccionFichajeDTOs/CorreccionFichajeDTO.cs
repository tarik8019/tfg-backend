namespace ApiRest.Models.DTOs.CorreccionFichajeDTOs
{
    public class CorreccionFichajeDTO
    {

        public int IdCorreccion { get; set; }
        public int IdEmpleado { get; set; }
        public int IdFichaje { get; set; }
        public string Motivo { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
