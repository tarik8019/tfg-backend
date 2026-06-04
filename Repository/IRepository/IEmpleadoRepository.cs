using ApiRest.Models.Entity;
namespace ApiRest.Repository.IRepository
{
    public interface IEmpleadoRepository : IRepository<EmpleadoEntity>
    {

        Task<EmpleadoEntity?> GetEmpleadoByEmailAsync(string email);
        Task<EmpleadoEntity?> GetEmpleadoByUsuarioAsync(int idUsuario);
        Task<EmpleadoEntity?> GetEmpleadoByIdAsync(int idEmpleado);
    }
}
