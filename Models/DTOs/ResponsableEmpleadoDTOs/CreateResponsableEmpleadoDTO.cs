using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.ResponsableEmpleadoDTOs
{
    public class CreateResponsableEmpleadoDTO
    {

            [Required]
            public int IdEmpleado { get; set; }

            [Required]
            public int IdResponsable { get; set; }

            [Required]
            public int IdEmpresa { get; set; }

            [Required]
            public DateTime FechaInicio { get; set; }

            [Required]
            public DateTime FechaFin { get; set; }

            [Required]
            public TipoResponsabilidad TipoResponsabilidad { get; set; }

            [Required]
            public string Observaciones { get; set; } = default!;

            [Required]
            public bool Activo { get; set; }
        
    }

}

