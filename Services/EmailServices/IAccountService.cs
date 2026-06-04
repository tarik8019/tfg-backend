using ApiRest.Models.Entity;

namespace ApiRest.Services.EmailServices
{
    public interface IAccountService
    {
        Task SendActivationEmailAsync(AppUser user, string token, string role);
    }
}
