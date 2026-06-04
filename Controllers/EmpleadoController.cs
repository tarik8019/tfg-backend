using ApiRest.Models.DTOs.EmpleadoDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Authorize(Roles = "Administrador, Empleado")]
    [Route("api/empleados")]
    [ApiController]
    public class EmpleadoController : BaseController<EmpleadoEntity, EmpleadoDTO, CreateEmpleadoDTO>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        public EmpleadoController(IEmpleadoRepository empleadoRepository,
            IMapper mapper, ILogger<EmpleadoController> logger)
            : base(empleadoRepository, mapper, logger)
        {
            _empleadoRepository = empleadoRepository;
        }

          

            [HttpGet("by-email/{email}")]
            public async Task<ActionResult<EmpleadoDTO>> GetEmpleadoByEmail(string email)
            {
                try
                {
                    var entity = await _empleadoRepository.GetEmpleadoByEmailAsync(email);

                    if (entity == null)
                        return NotFound($"No se encontró un empleado con email {email}"); // 404 si no existe

                    var dto = _mapper.Map<EmpleadoDTO>(entity);
                    return Ok(new { result = dto }); // 200 con el empleado
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener el empleado por email {email}", email);
                    return StatusCode(500, "Ocurrió un error en el servidor.");
                }
            }

        [HttpGet("by-usuario/{idUsuario}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleadoByUsuario(int idUsuario)
        {
            try
            {
                var entity = await _empleadoRepository.GetEmpleadoByUsuarioAsync(idUsuario);

                if (entity == null)
                    return NotFound($"No se encontró un empleado con usuario {idUsuario}"); // 404 si no existe

                var dto = _mapper.Map<EmpleadoDTO>(entity);
                return Ok(new { result = dto }); // 200 con el empleado
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el empleado por idUsuario {idUsuario}", idUsuario);
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }

    }



}
