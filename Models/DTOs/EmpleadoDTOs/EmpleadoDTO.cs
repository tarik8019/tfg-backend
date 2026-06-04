using ApiRest.Models.DTOs.DepartamentoDTOs;
using ApiRest.Models.DTOs.EmpresaDTOs;
using ApiRest.Models.DTOs.UserDTOs;
using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.EmpleadoDTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }

        // Identificación
        public string CodigoEmpleado { get; set; } = string.Empty;

        // Datos personales
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string DniNie { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        // Dirección
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;

        // Laboral
        public PuestoEmpleado Puesto { get; set; } 
        public double SalarioBase { get; set; }
        public TipoContrato TipoContrato { get; set; } 
        public TipoJornada Jornada { get; set; } 
        public string Observaciones { get; set; } = string.Empty;

        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int SaldoVacaciones { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
        public bool IsActivo { get; set; }
        public DepartamentoNombres DepartamentoNombre { get; set; }

        public int idDepartamento { get; set; }
        public int idEmpresa { get; set; }
        public int idUsuario { get; set; }

    }
}
