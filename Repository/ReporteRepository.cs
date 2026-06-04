using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class ReporteRepository : GenericRepository<ReporteEntity>, IReporteRepository
    {
        public ReporteRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }

    }
}
