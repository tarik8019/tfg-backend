using ApiRest.Models.Entity;

namespace ApiRest.Models.DTOs.UserDTOs
{
    public class UserLoginResponseDto
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool IsActivo { get; set; }
        public int IdEmpresa { get; set; }  
        public string PictureUrl { get; set; } = string.Empty;

    }
}
