using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;

namespace ApiRest.Repository
{
        public class ResponsableRepository : GenericRepository<ResponsableEntity>, IResponsableRepository
        {
            public ResponsableRepository(ApplicationDbContext context, IMemoryCache cache)
                : base(context, cache)
            {
            }
        }    

}
