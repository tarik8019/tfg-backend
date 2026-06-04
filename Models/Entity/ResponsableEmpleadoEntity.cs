using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiRest.Models.Entity
{


   
        public class ResponsableEmpleadoEntity
        {
            [Key]
            public int IdResponsableEmpleado { get; set; }

            // Relación con Empleado
            [Required]
            public int IdEmpleado { get; set; }

            [ForeignKey(nameof(IdEmpleado))]
            public EmpleadoEntity Empleado { get; set; } = default!;

            // Relación con Responsable
            [Required]
            public int IdResponsable { get; set; }

            [ForeignKey(nameof(IdResponsable))]
            public ResponsableEntity Responsable { get; set; } = default!;

            // Relación con Empresa
            [Required]
            public int IdEmpresa { get; set; }

            [ForeignKey(nameof(IdEmpresa))]
            public EmpresaEntity Empresa { get; set; } = default!;

            [Required]
            public DateTime FechaInicio { get; set; }

            [Required]
            public DateTime FechaFin { get; set; }

            [Required]
            [StringLength(50)]
            public TipoResponsabilidad TipoResponsabilidad { get; set; } = default!;

            [Required]
            public string Observaciones { get; set; } = default!;

            [Required]
            public bool Activo { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; }

            [Required]
            public DateTime UpdatedAt { get; set; }
        }
    

}
