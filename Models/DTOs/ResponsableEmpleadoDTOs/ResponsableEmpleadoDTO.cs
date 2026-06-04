using ApiRest.Utils.Enum;

namespace ApiRest.Models.DTOs.ResponsableEmpleadoDTOs
{
    public class ResponsableEmpleadoDTO
    {


            public int IdResponsableEmpleado { get; set; }

            public int IdEmpleado { get; set; }
            public int IdResponsable { get; set; }
            public int IdEmpresa { get; set; }

            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }

            public TipoResponsabilidad TipoResponsabilidad { get; set; }

            public string Observaciones { get; set; } = default!;
            public bool Activo { get; set; }

            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        
    }
}

