using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.DocumentoEmpleadoDTOs
{
    public class CreateDocumentoEmpleadoDTO
    {

        [Required]
        public int IdEmpleado { get; set; }

        public TipoDocumentoEmpleado Tipo { get; set; }

        [MaxLength(255)]
        public string RutaArchivo { get; set; } = string.Empty;
    }
}
