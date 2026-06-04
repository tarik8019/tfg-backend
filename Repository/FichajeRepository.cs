using ApiRest.Data;
using ApiRest.Models.DTOs.FichajeDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Utils.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace ApiRest.Repository
{
    public class FichajeRepository : GenericRepository<FichajeEntity>, IFichajeRepository
    {
        public FichajeRepository(ApplicationDbContext context, IMemoryCache cache)
        : base(context, cache) { }



        public async Task<FichajeEntity?> GetUltimoFichajeByEmpleadoAsync(int idEmpleado)
        {
            return await _context.Fichajes
                .Where(f => f.IdEmpleado == idEmpleado)
                .OrderByDescending(f => f.Timestamp)
                .ThenByDescending(f => f.IdFichaje)
                .FirstOrDefaultAsync();
        }


        public async Task<SedeEntity?> GetSedeActivaEmpleadoAsync(int idEmpleado)
        {
            return await _context.AsignacionTurnos
                .Where(a =>
                    a.IdEmpleado == idEmpleado &&
                    a.Estado == EstadoAsignacionTurno.Confirmado
                )
                .Select(a => a.Turno.Sede)
                .FirstOrDefaultAsync();
        }



        public async Task<List<FichajeEntity>> GetFichajesHoyAsync()
        {
            var hoy = DateTime.Today;

            // Obtener fichajes del día actual
            var fichajesHoy = await _context.Fichajes
                .Where(f => f.Timestamp.Date == hoy)
                .OrderBy(f => f.IdEmpleado)       // Orden por empleado
                .ThenBy(f => f.Timestamp)        // Orden por hora del fichaje
                .ToListAsync();

            return fichajesHoy;
        }


        public async Task<List<FichajeEntity>> GetFichajesHoyPorEmpleado(int idEmpleado)
        {
            var hoy = DateTime.Today;
            var nextDay = hoy.AddDays(1);

            return await _context.Fichajes
                .Where(f => f.IdEmpleado == idEmpleado &&
                            f.Timestamp >= hoy &&
                            f.Timestamp < nextDay)
                .OrderBy(f => f.Timestamp)
                .ToListAsync();
        }


        public async Task<List<FichajesPorDiaDTO>> GetFichajesFiltradosAsync(
    string? nombre,
    string? apellidos,
    DateTime? fecha)
        {
            var query = _context.Fichajes
                .AsNoTracking()
                .Include(f => f.Empleado)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                var n = nombre.Trim().ToLower();

                query = query.Where(f =>
                    f.Empleado.Nombre.ToLower().Contains(n) ||
                    f.Empleado.Apellidos.ToLower().Contains(n) ||
                    (f.Empleado.Nombre + " " + f.Empleado.Apellidos).ToLower().Contains(n)
                );
            }

            if (fecha.HasValue)
            {
                var day = fecha.Value.Date;
                var nextDay = day.AddDays(1);

                query = query.Where(f =>
                    f.Timestamp >= day &&
                    f.Timestamp < nextDay
                );
            }

            var data = await query
                .OrderBy(f => f.Timestamp)
                .Select(f => new
                {
                    f.IdFichaje,
                    f.TipoFichaje,
                    f.Timestamp,
                    f.Latitud,
                    f.Longitud,
                    f.ValidadoFacial,
                    f.FuenteFichaje,
                    EmpleadoId = f.Empleado.IdEmpleado,
                    f.Empleado.Nombre,
                    f.Empleado.Apellidos
                })
                .ToListAsync();

            // AGRUPACIÓN DOBLE 
            return data
                .GroupBy(x => x.Timestamp.Date) // POR DÍA
                .Select(dia => new FichajesPorDiaDTO
                {
                    Fecha = dia.Key,

                    Empleados = dia
                        .GroupBy(x => new { x.EmpleadoId, x.Nombre, x.Apellidos }) // POR EMPLEADO
                        .Select(emp => new FichajesPorEmpleadoDTO
                        {
                            IdEmpleado = emp.Key.EmpleadoId,
                            Nombre = emp.Key.Nombre,
                            Apellidos = emp.Key.Apellidos,

                            Fichajes = emp
                                .OrderBy(f => f.Timestamp)
                                .Select(f => new FichajeDTO
                                {
                                    IdFichaje = f.IdFichaje,
                                    TipoFichaje = f.TipoFichaje.ToString(),
                                    Timestamp = f.Timestamp,
                                    Latitud = f.Latitud,
                                    Longitud = f.Longitud,
                                    ValidadoFacial = f.ValidadoFacial,
                                    FuenteFichaje = f.FuenteFichaje.ToString()
                                })
                                .ToList()
                        })
                        .ToList()
                })
                .OrderByDescending(x => x.Fecha)
                .ToList();
        }

        public async Task<TurnoEntity?> GetTurnoActivoEmpleadoAsync(int idEmpleado)
        {
            return await _context.AsignacionTurnos
                .Include(a => a.Turno)
                    .ThenInclude(t => t.Sede)
                .Where(a =>
                    a.IdEmpleado == idEmpleado &&
                    a.Estado == EstadoAsignacionTurno.Confirmado)
                .Select(a => a.Turno)
                .FirstOrDefaultAsync();
        }


    }
}
