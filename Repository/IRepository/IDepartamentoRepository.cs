using ApiRest.Models.Entity;
using ApiRest.Utils;

namespace ApiRest.Repository.IRepository
{
    public interface IDepartamentoRepository : IRepository<DepartamentoEntity>
    {

        Task<DepartamentoEntity?> GetByNombreStringAsync(int empresaId, string nombre);



    }
}
