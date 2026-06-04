using ApiRest.Models.DTOs.NotificacionDTOs;
using ApiRest.Models.DTOs.ReglaTurnoDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{   

    [Authorize(Roles = "Administrador")]
    [Route("api/ReglaTurno")]
    [ApiController]
    public class ReglaTurnoController : BaseController<ReglaTurnoEntity, ReglaTurnoDTO, CreateReglaTurnoDTO>
    {
        public ReglaTurnoController(IReglaTurnoRepository ReglaTurnoRepository,
            IMapper mapper, ILogger<ReglaTurnoController> logger)
            : base(ReglaTurnoRepository, mapper, logger)
        {

        }
    }
}
