using ApiRest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.UserDTOs
{
    public class UserRegistrationDto
    {

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field required: Email")]
        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; }

        [Required(ErrorMessage = "Field required: Role")]
        public string Rol { get; set; } = string.Empty;

        [Required]
        public int IdEmpresa { get; set; } // para asociar empresa

     
        public string? IdAppUser { get; set; } = string.Empty;

        // Campos opcionales para el frontend
        public string? PictureUrl { get; set; } // opcional
        public bool IsActivo { get; set; } = false; // opcional, sin valor por defecto
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } // opcional

    }

}
