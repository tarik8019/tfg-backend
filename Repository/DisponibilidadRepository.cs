using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class DisponibilidadRepository : GenericRepository<DisponibilidadEntity>, IDisponibilidadRepository
    {
        public DisponibilidadRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }

    }
}
