using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
  

  
        public class DepartamentoEntity
        {
            [Key]
            public int IdDepartamento { get; set; }

            // Relación con Empresa
            [Required]
            public int IdEmpresa { get; set; }

            [ForeignKey(nameof(IdEmpresa))]
            public EmpresaEntity? Empresa { get; set; } = default!;

            [Required]
            [StringLength(50)]
            public string CodigoDepartamento { get; set; } = default!;

            [Required]
            [StringLength(150)]
            public DepartamentoNombres Nombre { get; set; } = default!;

            [Required]
            public string Descripcion { get; set; } = default!;

            // Relación con ResponsableEmpleado
           
            public int? IdResponsableEmpleado { get; set; }

            [ForeignKey(nameof(IdResponsableEmpleado))]
            public ResponsableEmpleadoEntity? ResponsableEmpleado { get; set; } = default!;

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
