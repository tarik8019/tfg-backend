using ApiRest.Models.DTOs.AsignacionTurnoDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Utils.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers
{
    [Authorize]
    [Route("api/asignacion_turno")]
    [ApiController]
    public class AsignacionTurnoController : BaseController<AsignacionTurnoEntity, AsignacionTurnoDTO, CreateAsignacionTurnoDTO>
    {
        private readonly IAsignacionTurnoRepository _asignacionRepo;
        private readonly IMapper _mapper;

        public AsignacionTurnoController(
            IAsignacionTurnoRepository asignacionRepo,
            IMapper mapper,
            ILogger<AsignacionTurnoController> logger)
            : base(asignacionRepo, mapper, logger)
        {
            _asignacionRepo = asignacionRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override async Task<IActionResult> Create([FromBody] CreateAsignacionTurnoDTO createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdAsignaciones = new List<AsignacionTurnoDTO>();

                foreach (var idEmpleado in createDto.IdEmpleados)
                {
                    var existe = await _asignacionRepo.ExisteAsignacionAsync(
                    createDto.IdTurno,
                    idEmpleado
                );

                    if (existe)
                    {
                        return BadRequest(
                            $"El empleado {idEmpleado} ya tiene asignado este turno."
                        );
                    }
                    var entity = new AsignacionTurnoEntity
                    {
                        IdTurno = createDto.IdTurno,
                        IdEmpleado = idEmpleado,
                        Estado = createDto.Estado
                    };

                    var created = await _asignacionRepo.CreateAsync(entity);
                    if (!created)
                        throw new Exception($"No se pudo crear la asignación para el empleado {idEmpleado}");

                    createdAsignaciones.Add(_mapper.Map<AsignacionTurnoDTO>(entity));
                }

                var saved = await _asignacionRepo.Save();
                if (!saved)
                    throw new Exception("No se pudieron guardar las asignaciones en la base de datos");

                return Created("", new
                {
                    result = createdAsignaciones
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear asignaciones de turno");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrió un error al crear las asignaciones",
                    error = ex.Message
                });
            }
        }



        [Authorize(Roles = "Administrador, Empleado")]
        [HttpPut("sin-turno")]
        public async Task<IActionResult> UpdateWithIdTurno(
        [FromBody] AsignacionTurnoUpdateDTO dto)
        {
            if (!await _asignacionRepo.ExisteTurnoAsync(dto.IdTurno))
                return BadRequest("El turno indicado no existe.");

            if (!Enum.TryParse<EstadoAsignacionTurno>(dto.Estado, out var estado))
                return BadRequest("Estado inválido.");

            var empleadosRequest = dto.IdEmpleados.Distinct().ToList();

            // Obtener TODAS las asignaciones actuales del turno
            var asignacionesActuales =
                await _asignacionRepo.GetAsignacionesPorTurnoAsync(dto.IdTurno);

            var resultado = new List<AsignacionTurnoDTO>();

            // BORRAR las asignaciones de empleados que ya NO vienen
            foreach (var asignacion in asignacionesActuales)
            {
                if (!empleadosRequest.Contains(asignacion.IdEmpleado))
                {
                    _asignacionRepo.DeleteSinSave(asignacion);
                }
            }

            // CREAR o ACTUALIZAR las asignaciones que SÍ vienen
            foreach (var idEmpleado in empleadosRequest)
            {
                if (!await _asignacionRepo.ExisteEmpleadoAsync(idEmpleado))
                    continue;

                var asignacion =
                    asignacionesActuales.FirstOrDefault(a => a.IdEmpleado == idEmpleado);

                if (asignacion != null)
                {
                    // UPDATE
                    asignacion.Estado = estado;
                    _asignacionRepo.UpdateSinSave(asignacion);
                }
                else
                {
                    // CREATE
                    asignacion = await _asignacionRepo.CreateAsignacionAsync(
                        dto.IdTurno,
                        idEmpleado,
                        estado
                    );
                }

                resultado.Add(new AsignacionTurnoDTO
                {
                    IdAsignacion = asignacion.IdAsignacion,
                    IdTurno = asignacion.IdTurno,
                    IdEmpleado = asignacion.IdEmpleado,
                    Estado = asignacion.Estado.ToString()
                });
            }

            await _asignacionRepo.SaveAsync();

            return Ok(resultado);
        }




        [HttpGet("empleado/{idEmpleado:int}")]
        [Authorize(Roles = "Administrador, Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsignacionesPorEmpleado(int idEmpleado)
        {
            try
            {
                var entities = await _asignacionRepo.GetByEmpleadoAsync(idEmpleado);

                if (entities == null || !entities.Any())
                    return NotFound($"No hay asignaciones para el empleado {idEmpleado}");

                var dto = _mapper.Map<List<AsignacionTurnoDTO>>(entities);

                return Ok(new
                {
                    result = dto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener asignaciones del empleado {idEmpleado}", idEmpleado);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Error al obtener las asignaciones",
                    error = ex.Message
                });
            }
        }

        [HttpGet("con-turno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllWithTurno()
        {
            try
            {
                // Obtén asignaciones con turno incluido
                var entities = await ((IAsignacionTurnoRepository)_repository).GetAllWithTurnoAsync();

                // Mapea a DTO
                var dtos = _mapper.Map<List<AsignacionTurnoDTO>>(entities);

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching asignaciones con turno");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
