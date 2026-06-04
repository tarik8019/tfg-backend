using ApiRest.Models.DTOs.SolicitudAusenciaDTOs;
using ApiRest.Models.DTOs.TurnoDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ApiRest.Controllers
{ 
    [Authorize(Roles = "Administrador")]
    [Route("api/turno")]
    [ApiController]
    public class TurnoController : BaseController<TurnoEntity, TurnoDTO, CreateTurnoDTO>
    {
        public TurnoController(ITurnoRepository TurnoRepository,
            IMapper mapper, ILogger<TurnoController> logger)
            : base(TurnoRepository, mapper, logger)
        {

        }

        [HttpGet("con-sede")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllWithSede()
        {
            try
            {
               
                var entities = await ((ITurnoRepository)_repository).GetAllWithSedeAsync();

                // Mapea a DTO
                var dtos = _mapper.Map<List<TurnoDTO>>(entities);

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching turnos con sede");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
