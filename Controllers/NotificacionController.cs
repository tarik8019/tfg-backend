using ApiRest.Models.DTOs.FichajeDTOs;
using ApiRest.Models.DTOs.NotificacionDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/Notificacion")]
    [ApiController]
    public class NotificacionController : BaseController<NotificacionEntity, NotificacionDTO, CreateNotificacionDTO>
    {
        public NotificacionController(INotificacionRepository NotificacionRepository,
            IMapper mapper, ILogger<NotificacionController> logger)
            : base(NotificacionRepository, mapper, logger)
        {

        }
    }
}
