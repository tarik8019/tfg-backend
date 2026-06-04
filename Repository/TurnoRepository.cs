using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{ 
    public class TurnoRepository : GenericRepository<TurnoEntity>, ITurnoRepository
    {
        public TurnoRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }

        public async Task<List<TurnoEntity>> GetAllWithSedeAsync()
        {
            return await _context.Turnos
                .Include(t => t.Sede) // Incluye la sede
                .ToListAsync();
        }

    }
}
