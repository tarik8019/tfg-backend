using ApiRest.Utils.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class ReporteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReporte { get; set; }

        [Required]
        public TipoReporte TipoReporte { get; set; } // asistencia, ausencias, horas extra, nomina

        [Required]
        public DateTime FechaGeneracion { get; set; } = DateTime.Now;

        [Required, MaxLength(255)]
        public string ArchivoUrl { get; set; } = string.Empty;
    }
}
