using ApiRest.Application.Interfaces;
using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Services.EmailServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

public class UsuarioService : IUsuarioService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly AccountService _accountService;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(
        UserManager<AppUser> userManager,
        ApplicationDbContext context,
        AccountService accountService,
        ILogger<UsuarioService> logger)
    {
        _userManager = userManager;
        _context = context;
        _accountService = accountService;
        _logger = logger;
    }

    public async Task<AppUser> CrearUsuarioAsync(
    string nombre,
    string apellidos,
    string email,
    string rol,
    int empresaId,
    string idAppUser,
    bool isActivo,
    DateTime? createdAt ,
    DateTime? updatedAt ,
    string? pictureUrl )
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        if (existingUser != null)
        {
            _logger.LogInformation("Usuario {Email} ya existe", email);
            return null!;
        }

        var user = new AppUser
        {
            UserName = email,
            Email = email,
            Nombre = nombre,
            Apellidos = apellidos,
            EmailConfirmed = false,

        };

        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join(", ",
                result.Errors.Select(e => e.Description)));
        }

        await _userManager.AddToRoleAsync(user, rol);

        var usuarioEntity = new UsuarioEntity
        {
            Nombre = nombre,
            Apellidos = apellidos,
            Email = email,
            Rol = rol,
            IsActivo = false,
            IdAppUser = user.Id,
            IdEmpresa = empresaId,
            CreatedAt = createdAt ?? DateTime.UtcNow,
            UpdatedAt = updatedAt ?? DateTime.UtcNow,
            PictureUrl = pictureUrl,

        };

        _context.Usuarios.Add(usuarioEntity);
        await _context.SaveChangesAsync();

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        _logger.LogInformation("Token generado para {Email}: {Token}", user.Email, token);
        await _accountService.SendActivationEmailAsync(user, token, rol);

        return user;
    }
}
