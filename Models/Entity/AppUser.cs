using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ApiRest.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;

        override
        public string? Email { get; set; } = string.Empty;

    }
}



