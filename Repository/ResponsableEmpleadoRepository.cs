using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;

namespace ApiRest.Repository
{

        public class ResponsableEmpleadoRepository : GenericRepository<ResponsableEmpleadoEntity>, IResponsableEmpleadoRepository
        {
            public ResponsableEmpleadoRepository(ApplicationDbContext context, IMemoryCache cache)
                : base(context, cache)
            {
            }
        }
    

}
