using ApiRest.Models.Entity;
namespace ApiRest.Repository.IRepository
{
    public interface ITurnoRepository : IRepository<TurnoEntity>
    {

        Task<List<TurnoEntity>> GetAllWithSedeAsync();
    }
}
