using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Models;
using ApiRest.Utils.Enum;

namespace ApiRest.Models.Entity
{
    public class NotificacionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotificacion { get; set; }

        // FK hacia Usuario
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public UsuarioEntity Usuario { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Titulo { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Mensaje { get; set; } = string.Empty;

        [Required]
        public TipoNotificacion TipoNotificacion { get; set; } // push, automatica, alerta

        [Required]
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        [Required]
        public EstadoNotificacion EstadoNotificacion { get; set; } // pendiente, leida, archivada
    }
}
