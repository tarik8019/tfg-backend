using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class DocumentoEmpleadoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDocumento { get; set; }

        // FK hacia Empleado
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")]
        public EmpleadoEntity Empleado { get; set; } = null!;

        [Required]
        public TipoDocumentoEmpleado TipoDocumento { get; set; }

        [MaxLength(255)]
        public string RutaArchivo { get; set; } = string.Empty;
    }
}
