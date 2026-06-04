using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class ReglaTurnoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegla { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public TipoReglaTurno TipoReglaTurno { get; set; }

        [MaxLength(255)]
        public string Parametros { get; set; } = string.Empty; // JSON

        // FK hacia Turno
        public int IdTurno { get; set; }
        [ForeignKey("IdTurno")]
        public TurnoEntity Turno { get; set; } = null!;
    }
}
