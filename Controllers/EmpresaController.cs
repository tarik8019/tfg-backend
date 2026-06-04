using ApiRest.Models.DTOs.EmpleadoDTOs;
using ApiRest.Models.DTOs.EmpresaDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{

    [Authorize(Roles = "Administrador")]
    [Route("api/Empresa")]
    [ApiController]
    public class EmpresaController : BaseController<EmpresaEntity, EmpresaDTO, CreateEmpresaDTO>
    {
        public EmpresaController(IEmpresaRepository EmpresaRepository,
            IMapper mapper, ILogger<EmpresaController> logger)
            : base(EmpresaRepository, mapper, logger)
        {

        }
    }
}
