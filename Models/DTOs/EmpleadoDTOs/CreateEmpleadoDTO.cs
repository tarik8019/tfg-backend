using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.EmpleadoDTOs
{
    public class CreateEmpleadoDTO
    {
        // Identificación
        [Required, MaxLength(50)]
        public string CodigoEmpleado { get; set; } = string.Empty;

        // Datos personales
        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string DniNie { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        // Dirección
        [Required, MaxLength(150)]
        public string Direccion { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Ciudad { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Provincia { get; set; } = string.Empty;

        [Required, MaxLength(10)]
        public string CodigoPostal { get; set; } = string.Empty;

        // Laboral
        [Required]
        public PuestoEmpleado Puesto { get; set; } 

        [Required]
        public double SalarioBase { get; set; }

        [Required]
        public TipoContrato TipoContrato { get; set; } 

        [Required]
        public TipoJornada Jornada { get; set; } 

        [MaxLength(500)]
        public string Observaciones { get; set; } = string.Empty;

        [Required]
        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }

        public int SaldoVacaciones { get; set; } = 0;

        [MaxLength(255)]
        public string ImagenUrl { get; set; } = string.Empty;

        public bool IsActivo { get; set; } = false;

        // Relaciones
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        public int IdDepartamento { get; set; }

        [Required]
        public DepartamentoNombres DepartamentoNombre { get; set; }
    }
}
