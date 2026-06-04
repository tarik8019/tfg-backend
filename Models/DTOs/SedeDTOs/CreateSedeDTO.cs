using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.SedeDTOs
{
    public class CreateSedeDTO
    {

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        public decimal Latitud { get; set; }

        [Required]
        public decimal Longitud { get; set; }

        [Required]
        public int RadioGeofencing { get; set; }
    }
}
