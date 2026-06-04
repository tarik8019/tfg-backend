using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models.Entity
{
    public class EmpresaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }

        [Required, MaxLength(50)]
        public string CodigoEmpresa { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string CIF { get; set; } = string.Empty;

        [Required,MaxLength(100)]
        public string Direccion { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Ciudad { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Pais { get; set; } = string.Empty;

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Calculado (no se guarda en DB)
        [NotMapped]
        public int NumeroEmpleados => Empleados.Count;

        // Empresa tiene muchos Usuarios
        [JsonIgnore]
        public ICollection<UsuarioEntity> Usuarios { get; set; } = new List<UsuarioEntity>();

        // Empresa tiene muchos Empleados
        [JsonIgnore]
        public ICollection<EmpleadoEntity> Empleados { get; set; } = new List<EmpleadoEntity>();
    }
}
