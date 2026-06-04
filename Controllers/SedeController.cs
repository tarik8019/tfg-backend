using ApiRest.Models.DTOs.EmpresaDTOs;
using ApiRest.Models.DTOs.SedeDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
  
        [Authorize(Roles = "Administrador")]
        [Route("api/sede")]
        [ApiController]
        public class SedeController : BaseController<SedeEntity, SedeDTO, CreateSedeDTO>
        {
            public SedeController(ISedeRepository SedeRepository,
                IMapper mapper, ILogger<SedeController> logger)
                : base(SedeRepository, mapper, logger)
            {

            }
        }
    
}
