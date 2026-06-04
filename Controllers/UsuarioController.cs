using ApiRest.Application.Interfaces;
using ApiRest.Attributes;
using ApiRest.Data;
using ApiRest.Models.DTOs;
using ApiRest.Models.DTOs.ConfirmacionCuentaDTOs;
using ApiRest.Models.DTOs.UserDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Services.EmailServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ApiRest.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AccountService _accountService;
        private readonly IUserRepository _usuarioRepository;
        private readonly ApplicationDbContext _context;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper _mapper;

        public UsuarioController(
            IMapper mapper,
            ILogger<UsuarioController> logger,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AccountService accountService,
            ApplicationDbContext context,
            IUserRepository usuarioRepository,
            IUsuarioService usuarioService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountService = accountService;
            _usuarioRepository = usuarioRepository;
            _context = context;
            _usuarioService = usuarioService;
            _logger = logger;
            _mapper = mapper;
        }

        // ADMIN CREA USUARIO SIN CONTRASEÑA
        [Authorize(Roles = "Administrador")]
        [HttpPost("crear")]
        public async Task<IActionResult> CrearUsuario([FromBody] UserRegistrationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(dto.Rol))
                return BadRequest("El rol es obligatorio.");

            var user = await _usuarioService.CrearUsuarioAsync(
                dto.Nombre,
                dto.Apellidos,
                dto.Email,
                dto.Rol,
                dto.IdEmpresa,
                dto.PictureUrl!,
                dto.IsActivo
            );

            if (user == null)
                return BadRequest("El usuario ya existe.");

            return Ok(new
            {
                mensaje = "Usuario creado correctamente. Se envió email de activación.",
                userId = user.Id
            });
        }


        // USUARIO CONFIRMA EMAIL Y ESTABLECE CONTRASEÑA

        [AllowAnonymous]
        [HttpPost("activar-cuenta")]
        public async Task<IActionResult> ActivarCuenta([FromBody] ConfirmacionCuentaDTO dto)
        {
            //Validación básica de DTO
            var decodedToken = Uri.UnescapeDataString(dto.Token);
            if (string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Password) ||
                string.IsNullOrWhiteSpace(decodedToken))
            {
                return BadRequest(new { message = "Faltan campos requeridos: Email, Token o Password." });
            }

            // Buscar usuario
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return NotFound(new { message = "Usuario no encontrado." });

            //Validar la contraseña ANTES de guardarla
            var passwordValidator = new PasswordValidationAttribute();

            if (!passwordValidator.IsValid(dto.Password))
            {
                return BadRequest(new
                {
                    message = passwordValidator.FormatErrorMessage("Password")
                });
            }


            // Confirmar email con el token
            var confirmResult = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (!confirmResult.Succeeded)
            {
                var errors = string.Join(", ", confirmResult.Errors.Select(e => e.Description));
                return BadRequest(new { message = "Token inválido o expirado.", details = errors });
            }

            // Establecer contraseña
            var passwordResult = await _userManager.AddPasswordAsync(user, dto.Password);
            if (!passwordResult.Succeeded)
            {
                var errors = string.Join(", ", passwordResult.Errors.Select(e => e.Description));
                return BadRequest(new { message = "No se pudo establecer la contraseña.", details = errors });
            }

            //Activar UsuarioEntity
            var usuarioEntity = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (usuarioEntity != null)
            {
                usuarioEntity.IsActivo = true;
                await _context.SaveChangesAsync();
            }

            // OK
            return Ok(new { message = "Cuenta activada y contraseña establecida correctamente." });
        }

        [HttpGet("activar-cuenta")]
        public IActionResult RedirectToFlutter([FromQuery] string email, [FromQuery] string token)
        {
            // Deep link de Flutter
            var deepLink = $"myapp://activar-cuenta?email={email}&token={token}";

            // Redirige a Flutter (la app intercepta este enlace)
            return Redirect(deepLink);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetUsuarioByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest(new ResponseApi
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { "El email es obligatorio." }
                });

            var usuario = await _usuarioRepository.GetUsuarioByEmailAsync(email);

            if (usuario == null)
            {
                _logger.LogWarning("Usuario no encontrado: {Email}", email);
                return NotFound(new ResponseApi
                {
                    StatusCode = HttpStatusCode.NotFound,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { $"No existe un usuario con email '{email}'" }
                });
            }

            // Mapeamos la entidad a DTO
            var dto = _mapper.Map<UserFlutterDto>(usuario);

            // Aseguramos que rol y empresaId no sean nulos
            dto.Rol ??= "Empleado"; // o "Administrador" según corresponda
            dto.IdEmpresa = usuario.IdEmpresa;

            // Devolvemos la respuesta usando ResponseApi
            return Ok(new ResponseApi
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Result = dto
            });
        }


    }
}
