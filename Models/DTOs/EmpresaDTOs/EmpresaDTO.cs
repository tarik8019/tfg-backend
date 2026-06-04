using ApiRest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.EmpresaDTOs
{
    public class EmpresaDTO
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; } = null!;
        public string CodigoEmpresa { get; set; } = null!;
        public string CIF { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string Pais { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }

        public int CantidadUsuarios { get; set; } = 0;
        public int CantidadEmpleados { get; set; } = 0;
    }
}
