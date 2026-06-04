using ApiRest.Models.DTOs.AsignacionTurnoDTOs;
using ApiRest.Models.DTOs.CorreccionFichajeDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{

    [Authorize(Roles = "Administrador")]
    [Route("api/CorreccionFichaje")]
    [ApiController]
    public class CorreccionFichajeController : BaseController<CorreccionFichajeEntity, CorreccionFichajeDTO, CreateCorreccionFichajeDTO>
    {
        public CorreccionFichajeController(ICorreccionFichajeRepository CorreccionFichajeRepository,
            IMapper mapper, ILogger<CorreccionFichajeController> logger)
            : base(CorreccionFichajeRepository, mapper, logger)
        {

        }
    }
}
