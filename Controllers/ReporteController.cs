using ApiRest.Models.DTOs.ReporteDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ApiRest.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/Reporte")]
    [ApiController]
    public class ReporteController : BaseController<ReporteEntity, ReporteDTO, CreateReporteDTO>
    {
        public ReporteController(IReporteRepository ReporteRepository,
            IMapper mapper, ILogger<ReporteController> logger)
            : base(ReporteRepository, mapper, logger)
        {

        }
    }
}
