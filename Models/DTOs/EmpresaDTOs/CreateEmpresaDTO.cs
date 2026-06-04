using ApiRest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.EmpresaDTOs
{
    public class CreateEmpresaDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El CIF es obligatorio")]
        [MaxLength(20)]
        [CifValido]
        public string CIF { get; set; } = null!;

        [Required(ErrorMessage = "El CodigoEmpresa es obligatorio")]
        [MaxLength(20)]
        [CodigoEmpresaValido]
        public string CodigoEmpresa { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres")]
        public string? Direccion { get; set; }

        [MaxLength(50, ErrorMessage = "La ciudad no puede superar los 50 caracteres")]
        public string? Ciudad { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        [MaxLength(50, ErrorMessage = "El país no puede superar los 50 caracteres")]
        public string Pais { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "El número de empleados no puede ser negativo")]
        public int? NumeroEmpleados { get; set; } // opcional
    }
}
