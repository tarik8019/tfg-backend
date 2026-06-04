using ApiRest.Data;
using ApiRest.Models.DTOs.UserDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ApiRest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string secretKey;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly int TokenExpirationMinutes = 60;

        public UserRepository(ApplicationDbContext context, IConfiguration config,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _context = context;
            secretKey = config.GetValue<string>("ApiSettings:SecretKey");
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public AppUser GetUser(string id)
        {
            return _context.AppUsers.FirstOrDefault(user => user.Id == id);
        }
        public async Task<UsuarioEntity?> GetUsuarioAsync(int id)
        {
            return await _context.Usuarios
                .AsNoTracking() // evita que EF use datos en caché
                .FirstOrDefaultAsync(usuario => usuario.IdUsuario == id);
        }

        public async Task<UsuarioEntity?> GetUsuarioByUserIdAsync(String id)
        {
            return await _context.Usuarios
                .AsNoTracking() // evita que EF use datos en caché
                .FirstOrDefaultAsync(usuario => usuario.IdAppUser == id);
        }

        public ICollection<AppUser> GetUsers()
        {
            return _context.AppUsers.OrderBy(user => user.UserName).ToList();
        }

        public bool IsUniqueUser(string userName)
        {
            return !_context.AppUsers.Any(user => user.UserName == userName);
        }

        public async Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            
            var user = _context.AppUsers.FirstOrDefault(u => u.Email.ToLower() == userLoginDto.Email.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            //user doesn't exist ?
            if (user == null || !isValid)
            {
                return new UserLoginResponseDto { Token = "", Apellidos = "",
                Nombre = "", Email = "", Rol = ""};
            }

            var usuario = await GetUsuarioByUserIdAsync(user.Id);

            //User does exist
            var roles = await _userManager.GetRolesAsync(user);

            var tokenHandler = new JwtSecurityTokenHandler();

            if (secretKey.Length < 32)
            {
                throw new ArgumentException("The secret key must be at least 32 characters long.");
            }
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())

                }),
                Expires = DateTime.UtcNow.AddMinutes(TokenExpirationMinutes),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            UserLoginResponseDto userLoginResponseDto = new UserLoginResponseDto
            {
                Token = tokenHandler.WriteToken(jwtToken),
                Id = usuario!.IdUsuario,
                Apellidos = user.Apellidos,
                Nombre=user.Nombre,
                Email = user.Email!,
                Rol = roles.FirstOrDefault() ?? string.Empty,
                IdEmpresa = _context.Usuarios.FirstOrDefault(u => u.IdAppUser == user.Id)?.IdEmpresa ?? 0,
                IsActivo = _context.Usuarios.FirstOrDefault(u => u.IdAppUser == user.Id)?.IsActivo ?? false,
                PictureUrl = _context.Usuarios.FirstOrDefault(u => u.IdAppUser == user.Id)?.PictureUrl ?? string.Empty


            };
            return userLoginResponseDto;
        }


        // Crear usuario desde Admin (sin contraseña)
        public async Task<AppUser?> CreateUserByAdmin(UserRegistrationDto dto, string role)
        {
            // Verificar si ya existe
            var existing = await _userManager.FindByEmailAsync(dto.Email);
            if (existing != null) return null;

            var appUser = new AppUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
            };

            var result = await _userManager.CreateAsync(appUser); // Sin contraseña
            if (!result.Succeeded) return null;

            // Asignar rol si existe
            if (!string.IsNullOrEmpty(role) && await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(appUser, role);
            }

            // Crear UsuarioEntity ligado a AppUser
            var usuarioEntity = new UsuarioEntity
            {
                IdAppUser = appUser.Id,
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                Rol = role,
                IdEmpresa = dto.IdEmpresa,
                IsActivo = false
            };

            await _context.Usuarios.AddAsync(usuarioEntity);
            await _context.SaveChangesAsync();

            return appUser;
        }

        //  Generar token de confirmación
        public async Task<string> GenerateEmailConfirmationToken(string appUserId)
        {
            var appUser = await _userManager.FindByIdAsync(appUserId);
            if (appUser == null) throw new KeyNotFoundException("Usuario no encontrado");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            return token;
        }

        //  Confirmar email y establecer contraseña
        public async Task<bool> ConfirmEmailAndSetPassword(string email, string token, string password)
        {
            var appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null) return false;

            // Confirmar email
            var confirmResult = await _userManager.ConfirmEmailAsync(appUser, token);
            if (!confirmResult.Succeeded) return false;

            // Establecer contraseña si no tiene
            if (!await _userManager.HasPasswordAsync(appUser))
            {
                var passResult = await _userManager.AddPasswordAsync(appUser, password);
                if (!passResult.Succeeded) return false;
            }

            // Activar UsuarioEntity
            var usuarioEntity = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdAppUser == appUser.Id);
            if (usuarioEntity != null)
            {
                usuarioEntity.IsActivo = true;
                _context.Update(usuarioEntity);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        //  Obtener AppUser por Id
        public async Task<AppUser?> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        //  Obtener UsuarioEntity por AppUserId
        public async Task<UsuarioEntity?> GetUsuarioEntityByAppUserIdAsync(string appUserId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.IdAppUser == appUserId);
        }


        public async Task<UsuarioEntity?> GetUsuarioByEmailAsync(string email)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

    }
}



