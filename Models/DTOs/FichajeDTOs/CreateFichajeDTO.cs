using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.FichajeDTOs
{
    public class CreateFichajeDTO
    {

        [Required]
        public int IdEmpleado { get; set; }

        [Required]
        public TipoFichaje TipoFichaje { get; set; }

        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public FuenteFichaje FuenteFichaje { get; set; }
        public bool ValidadoFacial { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
