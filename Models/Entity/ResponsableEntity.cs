using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{

        public class ResponsableEntity
        {
            [Key]
            public int IdResponsable { get; set; }

            // Relación con Empleado
            [Required]
            public int IdEmpleado { get; set; }

            [ForeignKey(nameof(IdEmpleado))]
            public EmpleadoEntity Empleado { get; set; } = default!;

            // Relación con Empresa
            [Required]
            public int IdEmpresa { get; set; }

            [ForeignKey(nameof(IdEmpresa))]
            public EmpresaEntity Empresa { get; set; } = default!;

            [Required]
            [StringLength(100)]
            public CargoResponsable Cargo { get; set; } = default!;

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
