using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models.Entity
{
    public class FichajeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFichaje { get; set; }

        // FK hacia Empleado
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")]
        public EmpleadoEntity Empleado { get; set; } = null!;

        [Required]
        public TipoFichaje TipoFichaje { get; set; } // entrada, salida, pausa_inicio, pausa_fin

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Required]
        public decimal Latitud { get; set; }

        [Required]
        public decimal Longitud { get; set; }

        [Required]
        public bool ValidadoFacial { get; set; } = false;

        [Required]
        public FuenteFichaje FuenteFichaje { get; set; } // online/offline

        // Relaciones
        [JsonIgnore]
        public ICollection<CorreccionFichajeEntity> Correcciones { get; set; } = null!;
    }
}
