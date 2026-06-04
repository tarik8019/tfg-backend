
    using System.Text.Json.Serialization;

    namespace ApiRest.Models.DTOs.UserDTOs
    {
        public class UserFlutterDto
        {
            [JsonPropertyName("id")]
            public int? IdUsuario { get; set; }  // nullable para nuevos usuarios

            [JsonPropertyName("nombre")]
            public string Nombre { get; set; } = string.Empty;

            [JsonPropertyName("apellidos")]
            public string Apellidos { get; set; } = string.Empty;

            [JsonPropertyName("email")]
            public string Email { get; set; } = string.Empty;

            [JsonPropertyName("rol")]
            public string Rol { get; set; } = string.Empty;

            [JsonPropertyName("pictureUrl")]
            public string? PictureUrl { get; set; }

            [JsonPropertyName("idEmpresa")]
            public int IdEmpresa { get; set; }

            [JsonPropertyName("idAppUser")]
            public string? IdAppUser { get; set; } = string.Empty; // NUNCA devolve null al frontend

        [JsonPropertyName("isActivo")]
            public bool IsActivo { get; set; } // activo o no

            [JsonPropertyName("createdAt")]
            public DateTime? CreatedAt { get; set; }   // string para compatibilidad con frontend

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; } // opcional

            [JsonPropertyName("token")]
            public string? Token { get; set; } // opcional
        }
    }


