using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models.Entity
{
    public class TurnoEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTurno { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        [Required]
        public TipoTurno Nombre { get; set; }

        [Required]

        public bool esNocturno { get; set; }

        public int IdSede { get; set; }
        [ForeignKey("IdSede")]
        public SedeEntity Sede { get; set; } = null!;

        [JsonIgnore]
        public ICollection<AsignacionTurnoEntity> AsignacionesTurno { get; set; } = null!;
    }
}
