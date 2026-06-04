using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.ReglaTurnoDTOs
{
    public class CreateReglaTurnoDTO
    {


        [Required, MaxLength(255)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public TipoReglaTurno Tipo { get; set; }    
        public string Parametros { get; set; } = string.Empty;
    }
}
