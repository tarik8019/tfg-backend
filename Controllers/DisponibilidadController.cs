using ApiRest.Models.DTOs.CorreccionFichajeDTOs;
using ApiRest.Models.DTOs.DisponibilidadDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{

    [Authorize(Roles = "Administrador")]
    [Route("api/Disponibilidad")]
    [ApiController]
    public class DisponibilidadController : BaseController<DisponibilidadEntity, DisponibilidadDTO, CreateDisponibilidadDTO>
    {
        public DisponibilidadController(IDisponibilidadRepository DisponibilidadRepository,
            IMapper mapper, ILogger<DisponibilidadController> logger)
            : base(DisponibilidadRepository, mapper, logger)
        {

        }
    }
}
