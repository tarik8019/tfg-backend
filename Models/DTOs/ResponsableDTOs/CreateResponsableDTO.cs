using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.ResponsableDTOs
{
    public class CreateResponsableDTO
    {
            [Required]
            public int IdEmpleado { get; set; }

            [Required]
            public int IdEmpresa { get; set; }

            [Required]
            public CargoResponsable Cargo { get; set; }

            [Required]
            [EmailAddress]
            [StringLength(150)]
            public string EmailContacto { get; set; } = default!;

            [Required]
            [StringLength(20)]
            public string TelefonoContacto { get; set; } = default!;

            [Required]
            public bool Activo { get; set; }
    }
}


