using ApiRest.Models.DTOs.ReporteDTOs;
using ApiRest.Models.DTOs.SolicitudAusenciaDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ApiRest.Controllers
{
    [Authorize(Roles = "Empleado")]
    [Route("api/SolicitudAusencia")]
    [ApiController]
    public class SolicitudAusenciaController : BaseController<SolicitudAusenciaEntity, SolicitudAusenciaDTO, CreateSolicitudAusenciaDTO>
    {
        public SolicitudAusenciaController(ISolicitudAusenciaRepository SolicitudAusenciaRepository,
            IMapper mapper, ILogger<SolicitudAusenciaController> logger)
            : base(SolicitudAusenciaRepository, mapper, logger)
        {

        }
    }
}
