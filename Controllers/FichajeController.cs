using ApiRest.Models.DTOs.FichajeDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Services.GeoService;
using ApiRest.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    
    [Route("api/Fichaje")]
    [ApiController]
    public class FichajeController : BaseController<FichajeEntity, FichajeDTO, CreateFichajeDTO>
    {
        private readonly IFichajeRepository _fichajeRepository;
        private readonly IEmpleadoRepository _empleadoRepository;   
        private readonly IFichajeService _fichajeService;
        public FichajeController(IFichajeRepository fichajeRepository, IEmpleadoRepository empleadoRepository,
            IGeoService geoService,
            IFichajeService fichajeService,
            IMapper mapper,
            ILogger<FichajeController> logger)
            : base(fichajeRepository, mapper, logger)
        {
        
            _fichajeRepository = fichajeRepository;
            _empleadoRepository = empleadoRepository;
            _fichajeService = fichajeService;
        }

        [Authorize(Roles = "Empleado")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Create(
    [FromBody] CreateFichajeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result =
                    await _fichajeService.CrearFichajeAsync(dto);

                if (!result.Success)
                    return BadRequest(result.Error);

                var resultDto =
                    _mapper.Map<FichajeDTO>(result.Fichaje);

                return CreatedAtAction(nameof(Create), resultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error al crear el fichaje");

                return StatusCode(500,
                    "Error interno del servidor");
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("empleado/{idEmpleado}/ultimo")]
        public async Task<ActionResult<FichajeDTO>> GetUltimoFichaje(int idEmpleado)
        {
            try
            {
                var entity = await _fichajeRepository.GetUltimoFichajeByEmpleadoAsync(idEmpleado);

                if (entity == null)
                    return NoContent(); // 204 si no hay fichajes

                var dto = _mapper.Map<FichajeDTO>(entity);
                return Ok(dto); // 200 con el último fichaje
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el último fichaje de {idEmpleado}", idEmpleado);
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("hoy/agrupados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FichajesPorEmpleadoDTO>>> GetFichajesHoyAgrupados()
        {
            try
            {
                // Obtener todos los fichajes de hoy
                var hoy = DateTime.Today;
                var fichajesHoy = await _fichajeRepository.GetFichajesHoyAsync();

                // Filtrar por fecha de hoy
                fichajesHoy = fichajesHoy
                    .Where(f => f.Timestamp.Date == hoy)
                    .ToList();

                if (!fichajesHoy.Any())
                    return NoContent();

                // Agrupar por empleado
                var grouped = fichajesHoy
                    .GroupBy(f => f.IdEmpleado)
                    .Select(async g =>
                    {
                        var empleado = await _empleadoRepository.GetEmpleadoByIdAsync(g.Key);
                        return new FichajesPorEmpleadoDTO
                        {
                            IdEmpleado = g.Key,
                            Nombre = empleado?.Nombre ?? "Desconocido",
                            Apellidos = empleado?.Apellidos ?? "",
                            Fichajes = _mapper.Map<List<FichajeDTO>>(g.OrderBy(f => f.Timestamp).ToList())
                        };
                    })
                    .Select(t => t.Result) // esperar los tasks
                    .ToList();

                return Ok(grouped);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener fichajes agrupados por empleado");
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }


        [Authorize(Roles = "Administrador")]
        [HttpGet("buscar/agrupados-por-dia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<FichajesPorDiaDTO>>> GetFichajesFiltrados(
            [FromQuery] string? nombre,
            [FromQuery] string? apellidos,
            [FromQuery] DateTime? fecha)
        {
            try
            {
                var result = await _fichajeRepository
                    .GetFichajesFiltradosAsync(nombre, apellidos, fecha);

                if (result == null || !result.Any())
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar fichajes filtrados");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [Authorize(Roles = "Empleado")]
        [HttpGet("hoy/empleado/{idEmpleado}")]
            public async Task<IActionResult> GetFichajesHoyPorEmpleado(int idEmpleado)
            {
                var fichajes = await _fichajeRepository
                    .GetFichajesHoyPorEmpleado(idEmpleado);

                if (fichajes == null || !fichajes.Any())
                    return NoContent(); // 204

                return Ok(fichajes); // 200
            }
        

    }
}
