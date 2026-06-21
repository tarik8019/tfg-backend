using ApiRest.Models.DTOs.UserDTOs;
using ApiRest.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace ApiRest.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<AppUser> GetUsers();
        AppUser GetUser(string id);
        Task<UsuarioEntity> GetUsuarioAsync(int id);
        bool IsUniqueUser(string email);
        Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
        Task<AppUser?> CreateUserByAdmin(UserRegistrationDto dto, string role);
        Task<string> GenerateEmailConfirmationToken(string appUserId);
        Task<bool> ConfirmEmailAndSetPassword(string email, string token, string password);
        Task<AppUser?> GetByIdAsync(string id);
        Task<UsuarioEntity?> GetUsuarioEntityByAppUserIdAsync(string appUserId);

        Task<UsuarioEntity?> GetUsuarioByEmailAsync(string email);

        Task<string?> GenerarTokenActivacionAsync(string email);

    }
}
