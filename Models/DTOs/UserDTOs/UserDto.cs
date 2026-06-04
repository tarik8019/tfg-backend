namespace ApiRest.Models.DTOs.UserDTOs
{
    public class UserDto
    {
    

        public string? IdUsuario { get; set; }  // nullable para nuevos usuarios
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty; // empleado, supervisor, administrador
        public string? PictureUrl { get; set; }
        public int IdEmpresa { get; set; }
        public string? IdAppUser { get; set; }
        public bool IsActivo { get; set; } // activo o no
        public string CreatedAt { get; set; } = string.Empty; // string para compatibilidad con frontend
        public string? UpdatedAt { get; set; }   // opcional
    }
}
