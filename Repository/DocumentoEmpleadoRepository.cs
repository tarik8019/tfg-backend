using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class DocumentoEmpleadoRepository : GenericRepository<DocumentoEmpleadoEntity>, IDocumentoEmpleadoRepository
    {
        public DocumentoEmpleadoRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }

    }
}
