using ApiRest.Utils.Enum;
using System;
namespace ApiRest.Models.DTOs.DepartamentoDTOs
{
    public class DepartamentoDTO
    {
       
            public int IdDepartamento { get; set; }

            public int IdEmpresa { get; set; }
            public string CodigoDepartamento { get; set; } = default!;
            public DepartamentoNombres Nombre { get; set; } = default!;
            public string Descripcion { get; set; } = default!;

            public int? IdResponsableEmpleado { get; set; }

            public string EmailContacto { get; set; } = default!;
            public string TelefonoContacto { get; set; } = default!;
            public bool Activo { get; set; }

            public DateTime FechaCreacion { get; set; }
            public DateTime FechaActualizacion { get; set; }
        }
    

}

