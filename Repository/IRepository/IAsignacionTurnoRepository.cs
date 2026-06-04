using ApiRest.Models.Entity;
using ApiRest.Utils.Enum;
namespace ApiRest.Repository.IRepository
{
    public interface IAsignacionTurnoRepository : IRepository<AsignacionTurnoEntity>
    {
        Task<bool> ExisteAsignacionAsync(int idTurno, int idEmpleado);
        Task<List<AsignacionTurnoEntity>> GetByEmpleadoAsync(int idEmpleado);
        Task<List<AsignacionTurnoEntity>> GetAllWithTurnoAsync();
        Task SaveAsync();
        void UpdateSinSave(AsignacionTurnoEntity entity);
        void DeleteSinSave(AsignacionTurnoEntity entity);
        Task<bool> ExisteTurnoAsync(int idTurno);
        Task<bool> ExisteEmpleadoAsync(int idEmpleado);
        Task<AsignacionTurnoEntity> CreateAsignacionAsync(
        int idTurno,
        int idEmpleado,
        EstadoAsignacionTurno estado);
        Task<List<AsignacionTurnoEntity>> GetAsignacionesPorTurnoAsync(int idTurno);

    }
}
