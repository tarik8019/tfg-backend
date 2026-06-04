using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.CorreccionFichajeDTOs
{
    public class CreateCorreccionFichajeDTO
    {

        [Required]
        public int IdEmpleado { get; set; }

        [Required]
        public int IdFichaje { get; set; }

        [MaxLength(255)]
        public string Motivo { get; set; } = string.Empty;

        public EstadoCorreccionFichaje Estado { get; set; }
    }
}
