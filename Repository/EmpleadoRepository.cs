using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class EmpleadoRepository : GenericRepository<EmpleadoEntity>, IEmpleadoRepository
    {
        public EmpleadoRepository(ApplicationDbContext context, IMemoryCache cache)
            : base(context, cache) { }


        public async Task<EmpleadoEntity?> GetEmpleadoByEmailAsync(string email)
        {
            return await _context.Set<EmpleadoEntity>()
                                 .FirstOrDefaultAsync(e => e.Email.ToLower() == email.ToLower());
        }

        public async Task<EmpleadoEntity?> GetEmpleadoByUsuarioAsync(int idUsuario)
        {
            return await _context.Set<EmpleadoEntity>()
                                 .FirstOrDefaultAsync(e => e.IdUsuario == idUsuario);
        }

        public async Task<EmpleadoEntity?> GetEmpleadoByIdAsync(int idEmpleado)
        {
            return await _context.Set<EmpleadoEntity>()
                                 .FirstOrDefaultAsync(e => e.IdEmpleado == idEmpleado);
        }

    }
}
