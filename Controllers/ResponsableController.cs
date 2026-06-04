using ApiRest.Models.DTOs.ResponsableDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    namespace ApiRest.Controllers
    {
        [Authorize(Roles = "Administrador")]
        [Route("api/Responsable")]
        [ApiController]
        public class ResponsableController : BaseController<ResponsableEntity, ResponsableDTO, CreateResponsableDTO>
        {
            public ResponsableController(IResponsableRepository responsableRepository,
                IMapper mapper, ILogger<ResponsableController> logger)
                : base(responsableRepository, mapper, logger)
            {
            }
        }
    }


