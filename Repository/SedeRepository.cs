using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class SedeRepository : GenericRepository<SedeEntity>, ISedeRepository
    {
        public SedeRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }




        public new virtual async Task<bool> DeleteAsync(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);

            if (sede == null)
                return false;

            // VALIDACIONES DE NEGOCIO
            var tieneTurnos = await _context.Turnos
                .AnyAsync(t => t.IdSede == id);

            var tieneEmpleados = await _context.AsignacionTurnos
                .AnyAsync(a => a.Turno.IdSede == id);

            if (tieneTurnos || tieneEmpleados)
            {
                throw new InvalidOperationException(
                    "No se puede eliminar la sede porque tiene turnos o empleados asociados"
                );
            }

            _context.Sedes.Remove(sede);
            return await Save();
        }
    }
    }
