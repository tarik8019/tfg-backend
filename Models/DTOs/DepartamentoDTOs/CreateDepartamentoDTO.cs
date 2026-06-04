using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.DepartamentoDTOs
{
    public class CreateDepartamentoDTO
    {
      
            [Required]
            public int IdEmpresa { get; set; }

            [Required]
            [StringLength(50)]
            public string CodigoDepartamento { get; set; } = default!;

            [Required]
            public DepartamentoNombres Nombre { get; set; } = default!;

            [Required]
            public string Descripcion { get; set; } = default!;

            public int? IdResponsableEmpleado { get; set; }

            [Required]
            [EmailAddress]
            [StringLength(150)]
            public string EmailContacto { get; set; } = default!;

            [Required]
            [StringLength(20)]
            public string TelefonoContacto { get; set; } = default!;

            [Required]
            public bool Activo { get; set; }

            [Required]
            public DateTime FechaCreacion { get; set; }

            [Required]
            public DateTime FechaActualizacion { get; set; }
    }
    

}

