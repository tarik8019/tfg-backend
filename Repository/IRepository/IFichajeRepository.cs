using ApiRest.Models.DTOs.FichajeDTOs;
using ApiRest.Models.Entity;
namespace ApiRest.Repository.IRepository
{
    public interface IFichajeRepository : IRepository<FichajeEntity>
    {
        Task<FichajeEntity?> GetUltimoFichajeByEmpleadoAsync(int idEmpleado);
        Task<SedeEntity?> GetSedeActivaEmpleadoAsync(int idEmpleado);
        Task<List<FichajeEntity>> GetFichajesHoyAsync();
        Task<List<FichajeEntity>> GetFichajesHoyPorEmpleado(int idEmpleado);
        Task<List<FichajesPorDiaDTO>> GetFichajesFiltradosAsync(string? nombre, string? apellidos, DateTime? fecha);
        Task<TurnoEntity?> GetTurnoActivoEmpleadoAsync(int idEmpleado);
    }
}
