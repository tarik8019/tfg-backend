using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.Entity
{
    public class UsuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Rol { get; set; } = string.Empty;

        [Required]
        public bool IsActivo { get; set; } = false;

        [MaxLength(255)]
        public string? PictureUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string IdAppUser { get; set; } = string.Empty;

        [ForeignKey("IdAppUser")]
        public AppUser AppUser { get; set; } = null!;

        public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public EmpresaEntity Empresa { get; set; } = null!;
    }
}
