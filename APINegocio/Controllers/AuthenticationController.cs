using APINegocio.Aplications.Authentication.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Services.Interfaz;
using APINegocio.Aplications.Data.Interfaz;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINegocio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAIPNegocio _AuthenticationAIPNegocio;

        private readonly ITokenServices _TokenServices;

        private readonly IMapper _Mapper;

        public AuthenticationController(IAuthenticationAIPNegocio authenticationAIPNegocio, ITokenServices tokenServices,
            IMapper mapper)
        {
            this._AuthenticationAIPNegocio = authenticationAIPNegocio;
            this._TokenServices = tokenServices;
            this._Mapper = mapper;
        }


        [HttpPost("{Register}")]
        public async Task<IActionResult> Register(UsersRegisterDto modelDto)
        {

            modelDto.Email = modelDto.Email.ToLower(); //Passar el usuario a minuscula

            if (await _AuthenticationAIPNegocio.ExisteUser(modelDto.Email))
                return BadRequest("ESTE CORREO ELECTRONICO YA ESTA REGISTRADO" +
                    "POR FAVOR UTILIZAR OTRO CORREO ELECTRONICO PARA REGISTRARSE");

            var userNew = _Mapper.Map<Users>(modelDto);
            var userCreated = await _AuthenticationAIPNegocio.Registrar(userNew, modelDto.PasswordUser!);
            var userCreatedDto = _Mapper.Map<UsersListDto>(userCreated);

            return Ok(userCreatedDto);
        }

        [HttpPost("{Login}")]
        public async Task<IActionResult> Login(UsersLoginDto modelLoginDto)
        {
            var userFromRepo = await _AuthenticationAIPNegocio.Login(modelLoginDto.Email!, modelLoginDto.PasswordUser!);
            if (userFromRepo == null)
                return Unauthorized();

            var userMap = _Mapper.Map<UsersListDto>(modelLoginDto);
            var tokenSer = _TokenServices.CreateToken(userFromRepo);

            //Retornar un nuevo objeto con userMap y tokenSer
            return Ok(new
            {
                tokenSer = tokenSer,
                userMap = userMap,
            });
        }

    }
}
