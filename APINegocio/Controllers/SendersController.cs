using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINegocio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SendersController : ControllerBase
    {
        private readonly ILogisticaService _LogisticaService;
        private readonly IMapper _Mapper;

        public SendersController(ILogisticaService logisticaService, IMapper mapper)
        {
            _LogisticaService = logisticaService;
            _Mapper = mapper;
        }

        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id) 
        {
          var deleted = await _LogisticaService.GetSendersByIdAsync(Id);
            if (deleted == null)
                return NotFound("ERROR!... EL REMITENTE QUE DESEA ELIMINAR NO FUE ENCONTRADO");

            _LogisticaService.Remove(deleted);
            if (!await _LogisticaService.SaveAll())
                return BadRequest("ERROR!... NO SE PUEDE ELIMINAR EL REMINTENTE");

            return Ok("EL REMITENTE FUE ELIMINADO");
        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSenders() 
        {
            var get = await _LogisticaService.GetSenders();
            if (get == null)
                return BadRequest("LOS REMITENTE QUE DESEA VER NO SE ENCUENTRAN DISPONIBLE");

            return Ok(get);
        
        }

        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int Id) 
        {
            var getById = await _LogisticaService.GetSendersByIdAsync(Id);
            if (getById == null)
                return NotFound("EL ID DEL REMITENTE QUE BUSCA, NO EXISTE");

            return Ok(getById);
        
        }

        [AllowAnonymous]
        [HttpGet("name/{name}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetName(Senders model) 
        {
            var getName = await _LogisticaService.GetSendersByNameAsync(model.SenderName!);
            return Ok(getName);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(SendersPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] SendersPOSTDto modelDto) 
        {
            var post = _Mapper.Map<Senders>(modelDto);
            _LogisticaService.Add(post);

            if(await _LogisticaService.SaveAll())
                return Ok(post);
            return BadRequest("REMITENTE REGISTRADO CORRECTAMENTE");
        
        }

        [AllowAnonymous]
        [HttpGet("code/{code}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Senders model) 
        {
            var getCode = await _LogisticaService.GetSendersByCodeAsync(model.SenderCode!);
            return Ok(getCode);
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(BranchOfficesPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, [FromBody] SendersPUTDto modelDto) 
        {
          if(Id != modelDto.SenderId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN REMITENTE");

          var get = await _LogisticaService.GetSendersByIdAsync(modelDto.SenderId!);
            if (get == null)
                return BadRequest();

            _Mapper.Map(modelDto, get);

            if (!await _LogisticaService.SaveAll()) 
                return NoContent();

            return Ok();
        }
    }
}
