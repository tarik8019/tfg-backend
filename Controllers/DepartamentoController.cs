using ApiRest.Controllers;
using ApiRest.Models.DTOs.DepartamentoDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Administrador")]
[Route("api/departamento")]
[ApiController]
public class DepartamentoController
    : BaseController<DepartamentoEntity, DepartamentoDTO, CreateDepartamentoDTO>
{
    private readonly IDepartamentoRepository _departamentoRepository;
    private readonly IMapper _mapper;


    public DepartamentoController(
        IDepartamentoRepository departamentoRepository,
        IMapper mapper,
        ILogger<DepartamentoController> logger
    ) : base(departamentoRepository, mapper, logger)
    {
        _departamentoRepository = departamentoRepository;
        _mapper = mapper;
    }



    [HttpGet("by-nombre/{empresaId}/{nombre}")]
    public async Task<IActionResult> GetByNombre(int empresaId, string nombre)
    {
        var departamento = await _departamentoRepository.GetByNombreStringAsync(empresaId, nombre);

        if (departamento == null)
            return NotFound();

        return Ok(_mapper.Map<DepartamentoDTO>(departamento));
    }






}
