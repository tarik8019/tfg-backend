using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class CorreccionFichajeRepository : GenericRepository<CorreccionFichajeEntity>, ICorreccionFichajeRepository
    {
            public CorreccionFichajeRepository(ApplicationDbContext context, IMemoryCache cache)
            : base(context, cache) { }
        
    }
}
