using ApiRest.Models.DTOs.DisponibilidadDTOs;
using ApiRest.Models.DTOs.DocumentoEmpleadoDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/DocumentoEmpleado")]
    [ApiController]
    public class DocumentoEmpleadoController : BaseController<DocumentoEmpleadoEntity, DocumentoEmpleadoDTO, CreateDocumentoEmpleadoDTO>
    {
        public DocumentoEmpleadoController(IDocumentoEmpleadoRepository DocumentoEmpleadoRepository,
            IMapper mapper, ILogger<DocumentoEmpleadoController> logger)
            : base(DocumentoEmpleadoRepository, mapper, logger)
        {

        }
    }
}
