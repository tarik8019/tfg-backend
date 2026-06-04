using ApiRest.Data;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Utils.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class AsignacionTurnoRepository : GenericRepository<AsignacionTurnoEntity>, IAsignacionTurnoRepository
    {
        private readonly ApplicationDbContext _context;
        public AsignacionTurnoRepository(
            ApplicationDbContext context,
            IMemoryCache cache
            )
        : base(context, cache) {

            _context = context;
        }


        public async Task<bool> ExisteAsignacionAsync(int idTurno, int idEmpleado)
        {
            return await _context.AsignacionTurnos.AnyAsync(a =>
                a.IdTurno == idTurno &&
                a.IdEmpleado == idEmpleado
            );
        }

        public async Task<List<AsignacionTurnoEntity>> GetByEmpleadoAsync(int idEmpleado)
        {
            return await _context.AsignacionTurnos
                .Where(a => a.IdEmpleado == idEmpleado)
                .Include(a => a.Turno)
                .ToListAsync();
        }

        public async Task<List<AsignacionTurnoEntity>> GetAllWithTurnoAsync()
        {
            return await _context.AsignacionTurnos
                .Include(a => a.Turno)       // Incluye el turno
                    .ThenInclude(t => t.Sede) // Incluye la sede del turno
                .ToListAsync();
        }


        // UPDATE SIN SAVE
        public void UpdateSinSave(AsignacionTurnoEntity entity)
        {
            _context.AsignacionTurnos.Update(entity);
        }

        // DELETE SIN SAVE
        public void DeleteSinSave(AsignacionTurnoEntity entity)
        {
            _context.AsignacionTurnos.Remove(entity);
        }


        // SAVE ÚNICO
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
            ClearCache();
        }

        public async Task<bool> ExisteTurnoAsync(int idTurno)
        {
            return await _context.Turnos.AnyAsync(t => t.IdTurno == idTurno);
        }

        public async Task<bool> ExisteEmpleadoAsync(int idEmpleado)
        {
            var existe = await _context.Empleados.AnyAsync(e => e.IdEmpleado == idEmpleado);
            Console.WriteLine($"Empleado {idEmpleado} existe: {existe}");
            return existe;
        }  

        public async Task<AsignacionTurnoEntity> CreateAsignacionAsync(
        int idTurno,
        int idEmpleado,
        EstadoAsignacionTurno estado)
        {
            var asignacion = new AsignacionTurnoEntity
            {
                IdTurno = idTurno,
                IdEmpleado = idEmpleado,
                Estado = estado
            };

            await _context.AsignacionTurnos.AddAsync(asignacion);
            return asignacion;
        }


        public async Task<List<AsignacionTurnoEntity>> GetAsignacionesPorTurnoAsync(int idTurno)
        {
            return await _context.AsignacionTurnos
                .Where(a => a.IdTurno == idTurno)
                .ToListAsync();
        }


    }


}
