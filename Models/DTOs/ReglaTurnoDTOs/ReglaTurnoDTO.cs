namespace ApiRest.Models.DTOs.ReglaTurnoDTOs
{
    public class ReglaTurnoDTO
    {

        public int IdRegla { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Parametros { get; set; } = string.Empty;
    }
}
