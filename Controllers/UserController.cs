using ApiRest.Models.DTOs;
using ApiRest.Models.DTOs.UserDTOs;
using ApiRest.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace ApiRest.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        protected ResponseApi _reponseApi;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _reponseApi = new ResponseApi();
            _mapper = mapper;
        }

        //[Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetUsers()
        {
            var userList = _userRepository.GetUsers();
            var userListDto = new List<UserDto>();

            foreach (var user in userList)
            {
                userListDto.Add(_mapper.Map<UserDto>(user));
            }

            return Ok(userListDto);
        }

        //[Authorize(Roles = "admin")]
        [HttpGet("{userId:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(string userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null) { return NotFound(); }

            return Ok(_mapper.Map<UserDto>(user));
        }

       


        //[AllowAnonymous]
        //[HttpPost("login")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        //{
        //    var responseLogin = await _userRepository.Login(userLoginDto);

        //    if (responseLogin.User == null || string.IsNullOrEmpty(responseLogin.Token))
        //    {
        //        _reponseApi.StatusCode = HttpStatusCode.BadRequest;
        //        _reponseApi.IsSuccess = false;
        //        _reponseApi.ErrorMessages.Add("Incorrect user and password");
        //        return BadRequest(_reponseApi);
        //    }

        //    _reponseApi.StatusCode = HttpStatusCode.OK;
        //    _reponseApi.IsSuccess = true;
        //    _reponseApi.Result = responseLogin;
        //    return Ok(_reponseApi);
        //}



        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            // Llamada al repositorio para autenticar
            var responseLogin = await _userRepository.Login(userLoginDto);

            //  Verificar si hubo error de login
            if (responseLogin.Nombre == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                _reponseApi.StatusCode = HttpStatusCode.BadRequest;
                _reponseApi.IsSuccess = false;
                _reponseApi.ErrorMessages.Add("Incorrect user and password");
                return BadRequest(_reponseApi);
            }

            //  Obtener UsuarioEntity relacionado para extraer el rol
            var usuarioEntity = await _userRepository.GetUsuarioAsync(responseLogin.Id);


            //  Crear DTO de respuesta
            var responseDto = new UserLoginResponseDto
            {    
                Id = responseLogin.Id,
                Nombre = responseLogin.Nombre,
                Apellidos = responseLogin.Apellidos,
                Email = responseLogin.Email,
                Rol = responseLogin.Rol,
                Token = responseLogin.Token,
                IsActivo = responseLogin.IsActivo,
                PictureUrl = responseLogin.PictureUrl,
                IdEmpresa = responseLogin.IdEmpresa,
            };

            //  Devolver la respuesta usando la misma estructura
            _reponseApi.StatusCode = HttpStatusCode.OK;
            _reponseApi.IsSuccess = true;
            _reponseApi.Result = responseDto;

            return Ok(_reponseApi);
        }


    }
}
