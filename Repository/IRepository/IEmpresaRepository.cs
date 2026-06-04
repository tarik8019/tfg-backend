using ApiRest.Models.Entity;
namespace ApiRest.Repository.IRepository
{
    public interface IEmpresaRepository : IRepository<EmpresaEntity>
    {

        Task<EmpresaEntity?> GetEmpresaWithEmpleadosAsync(int id);

    }
}
