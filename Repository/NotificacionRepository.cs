using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class NotificacionRepository : GenericRepository<NotificacionEntity>, INotificacionRepository
    {
        public NotificacionRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }
    }
}
