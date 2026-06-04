using ApiRest.Models.DTOs.ResponsableEmpleadoDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    namespace ApiRest.Controllers
    {
        [Authorize(Roles = "Administrador")]
        [Route("api/ResponsableEmpleado")]
        [ApiController]
        public class ResponsableEmpleadoController : BaseController<ResponsableEmpleadoEntity, ResponsableEmpleadoDTO, CreateResponsableEmpleadoDTO>
        {
            public ResponsableEmpleadoController(IResponsableEmpleadoRepository responsableEmpleadoRepository,
                IMapper mapper, ILogger<ResponsableEmpleadoController> logger)
                : base(responsableEmpleadoRepository, mapper, logger)
            {
            }
        }
    }


