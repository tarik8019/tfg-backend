using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{  
        public class EmpresaRepository : GenericRepository<EmpresaEntity>, IEmpresaRepository
        {
            public EmpresaRepository(ApplicationDbContext context, IMemoryCache cache)
            : base(context, cache) { }

        public async Task<EmpresaEntity?> GetEmpresaWithEmpleadosAsync(int id)
        {
            return await _context.Empresas
                .Include(e => e.Empleados)   // colección Empleados
                .Include(e => e.Usuarios)    // colección Usuarios (AppUser)
                .FirstOrDefaultAsync(e => e.IdEmpresa == id);
        }


    }

}
