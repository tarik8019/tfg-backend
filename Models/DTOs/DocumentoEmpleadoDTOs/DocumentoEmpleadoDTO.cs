namespace ApiRest.Models.DTOs.DocumentoEmpleadoDTOs
{
    public class DocumentoEmpleadoDTO
    {

        public int IdDocumento { get; set; }
        public int IdEmpleado { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string RutaArchivo { get; set; } = string.Empty;
    }
}
