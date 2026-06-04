using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ApiRest.Repository
{
    public class DepartamentoRepository
        : GenericRepository<DepartamentoEntity>, IDepartamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoRepository(
            ApplicationDbContext context,
            IMemoryCache cache
        ) : base(context, cache)
        {
            _context = context;
        }





        public async Task<DepartamentoEntity?> GetByNombreStringAsync(int empresaId, string nombre)
        {
            return await _context.Departamentos
                .FirstOrDefaultAsync(d =>
                    d.IdEmpresa == empresaId &&
                    d.Nombre.ToString().ToLower() == nombre.ToLower());
        }


    }
}
