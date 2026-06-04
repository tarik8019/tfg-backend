using ApiRest.Models.Entity;

namespace ApiRest.Application.Interfaces
{
    public interface IUsuarioService
    {

        Task<AppUser> CrearUsuarioAsync(
            string nombre,
            string apellidos,
            string email,
            string rol,
            int empresaId,
            string idAppUser,
            bool isActivo = false,
            DateTime? createdAt = null,
            DateTime? updatedAt = null,
            string? pictureUrl = null
      );
    }
}


