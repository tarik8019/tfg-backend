using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class SolicitudAusenciaRepository : GenericRepository<SolicitudAusenciaEntity>, ISolicitudAusenciaRepository
    {
        public SolicitudAusenciaRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }
    }
}
