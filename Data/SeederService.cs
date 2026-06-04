using ApiRest.Application.Interfaces;
using ApiRest.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Data
{
    public class SeederService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUsuarioService _usuarioService;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SeederService> _logger;

        public SeederService(
            RoleManager<IdentityRole> roleManager,
            IUsuarioService usuarioService,
            ApplicationDbContext context,
            ILogger<SeederService> logger)
        {
            _roleManager = roleManager;
            _usuarioService = usuarioService;
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogInformation("Iniciando proceso de seeding...");

            // Crear roles si no existen
            await EnsureRolesExistAsync(new[] { "Administrador", "Supervisor", "Empleado" });

            // Crear empresa inicial si no existe
            var empresa = await CreateEmpresaInicialAsync();

            // Crear usuario admin usando el servicio
            await _usuarioService.CrearUsuarioAsync(
                nombre: "Tarik",
                apellidos: "Salahi",
                email: "salahitarik@gmail.com",
                rol: "Administrador",
                empresaId: empresa.IdEmpresa,
                idAppUser: null!,
                isActivo: false,
                createdAt: DateTime.UtcNow,
                updatedAt: DateTime.UtcNow

            );

            _logger.LogInformation("Proceso de seeding completado.");
        }

        private async Task EnsureRolesExistAsync(string[] roles)
        {
            foreach (var roleName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                            _logger.LogError("Error creando rol {RoleName}: {Error}", roleName, error.Description);
                    }
                    else
                    {
                        _logger.LogInformation("Rol {RoleName} creado.", roleName);
                    }
                }
            }
        }

        private async Task<EmpresaEntity> CreateEmpresaInicialAsync()
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync();
            if (empresa != null)
                return empresa;

            empresa = new EmpresaEntity
            {
                Nombre = "Empresa Principal",
                CIF = "A15248545",
                CodigoEmpresa = "ABC123",
                Direccion = "Calle Juan Boscan 19",
                Ciudad = "Logroño",
                Pais = "España",
                FechaCreacion = DateTime.UtcNow
            };

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Empresa inicial creada con ID {Id}", empresa.IdEmpresa);

            return empresa;
        }
    }
}
