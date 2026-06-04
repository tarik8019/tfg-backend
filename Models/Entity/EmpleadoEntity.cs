using ApiRest.Utils.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models.Entity
{
    public class EmpleadoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; set; }

        // Campos básicos
        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public PuestoEmpleado Puesto { get; set; } 

        [Required, MaxLength(20)]
        public string DniNie { get; set; } = string.Empty;

        [Required]
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public int SaldoVacaciones { get; set; } = 0;

        
        public string ImagenUrl { get; set; } = string.Empty;

        [Required]
        public bool IsActivo { get; set; } = false;

        [Required, MaxLength(50)]
        public string CodigoEmpleado { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Direccion { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Ciudad { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Provincia { get; set; } = string.Empty;

        [Required, MaxLength(10)]
        public string CodigoPostal { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public double SalarioBase { get; set; }

        [Required, MaxLength(50)]
        public TipoContrato TipoContrato { get; set; }

        [Required, MaxLength(50)]
        public TipoJornada Jornada { get; set; }

        [MaxLength(500)]
        public string Observaciones { get; set; } = string.Empty;


        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public UsuarioEntity Usuario { get; set; } = null!;

        public int IdEmpresa { get; set; } 

        [ForeignKey("IdEmpresa")]
        public EmpresaEntity Empresa { get; set; } = null!;

        [Required]
        public int IdDepartamento { get; set; }

        [ForeignKey("IdDepartamento")]
        public DepartamentoEntity Departamento { get; set; } = null!;

        [Required]
        public DepartamentoNombres DepartamentoNombre { get; set; }


        [JsonIgnore]  
        public ICollection<AsignacionTurnoEntity> AsignacionesTurno { get; set; } = new List<AsignacionTurnoEntity>();
        [JsonIgnore]
        public ICollection<FichajeEntity> Fichajes { get; set; } = new List<FichajeEntity>();
        [JsonIgnore]
        public ICollection<SolicitudAusenciaEntity> SolicitudesAusencia { get; set; } = new List<SolicitudAusenciaEntity>();
        [JsonIgnore]
        public ICollection<CorreccionFichajeEntity> Correcciones { get; set; } = new List<CorreccionFichajeEntity>();
        [JsonIgnore]
        public ICollection<DocumentoEmpleadoEntity> Documentos { get; set; } = new List<DocumentoEmpleadoEntity>();
        [JsonIgnore]
        public ICollection<DisponibilidadEntity> Disponibilidades { get; set; } = new List<DisponibilidadEntity>();
    }
}
