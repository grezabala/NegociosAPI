using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace APINegocio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SendersController : ControllerBase
    {
        private readonly ILogisticaService _logisticaService;
        private readonly IMapper _mapper;

        public SendersController(ILogisticaService logisticaService, IMapper mapper)
        {
            _logisticaService = logisticaService;
            _mapper = mapper;
        }

        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var deleted = await _logisticaService.GetSendersByIdAsync(Id);

                if (!_logisticaService.GetSenderByIsDeleted(deleted))
                {
                    ModelState.AddModelError("", $"Error....! No fue posible eliminar el registro... {deleted}");
                    return StatusCode(500, ModelState);

                }

                return Ok("EL REMITENTE FUE ELIMINADO");
            }
            catch (Exception ex)
            {

                throw new Exception("Error....!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSenders()
        {

            try
            {
                var _getSenders = await _logisticaService.GetSenders();
                var _getSendersDto = new List<SendersDto>();

                foreach (var senders in _getSenders)
                {

                    _getSendersDto.Add(_mapper.Map<SendersDto>(senders));

                }

                return Ok(_getSendersDto);

                //if (get == null)
                //    return BadRequest("LOS REMITENTE QUE DESEA VER NO SE ENCUENTRAN DISPONIBLE");

                //return Ok(get);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{Id:int}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSenderById(int Id)
        {
            try
            {
                var _getById = await _logisticaService.GetSendersByIdAsync(Id);

                if (_getById != null)
                {
                    var _getByIdDto = new SendersDto()
                    {
                        SenderCode = _getById.SenderCode,
                        SenderName = _getById.SenderName,
                        SenderDirection = _getById.SenderDirection,
                        SenderEmail = _getById.SenderEmail,
                        SenderPhone = _getById.SenderPhone,
                        SenderId = _getById.SenderId,
                        SenderPostalCode = _getById.SenderPostalCode,
                        IsCreadSender = _getById.IsCreadSender,
                        IsAsset = _getById.IsAsset,

                        //OTRA MANERA DE UTILIZAR MAPPER... DE ESTA MANERA SOLO PUESDO MOSTRAR LO CAMPO QUE DESEO MAPPEAR
                    };

                    if (_getByIdDto == null)
                        return NotFound("EL ID DEL REMITENTE QUE BUSCA, NO EXISTE");

                    return Ok(_getByIdDto);
                }

                return NotFound("No se encontro el registro solicitado....");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetSenderByName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSenderByName(string nombre)
        {

            try
            {
                var getName = await _logisticaService.GetSendersByNameAsync(nombre);

                var getNameDto = new List<SendersDto>();

                foreach (var senders in getName)
                {
                    getNameDto.Add(_mapper.Map<SendersDto>(senders));
                }

                
                if (getNameDto == null)
                {
                    return NoContent();

                }

                return Ok(getNameDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(SendersPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] SendersPOSTDto modelDto)
        {
            try
            {
                var post = _mapper.Map<Senders>(modelDto);

                post.IsAsset = true;
                post.IsCreadSender = DateTime.Now;
                post.IsDeleted = false;
                post.IsDeletedAt = null;
                post.IsModifiedPostalCode = false;
                post.IsModifiedSender = false;
                post.IsDeletedAt = null;
                post.IsModifiedSenderDate = null;

                _logisticaService.Add(post);

                if (await _logisticaService.SaveAll())
                    return Ok(post);


                return BadRequest("REMITENTE REGISTRADO CORRECTAMENTE");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetSenderByCode")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSenderByCode(string code)
        {
            try
            {
                var getCode = await _logisticaService.GetSendersByCodeAsync(code);
                var _getCodeDto = new List<SendersDto>();

                foreach (var senders in getCode)
                {
                    _getCodeDto.Add(_mapper.Map<SendersDto>(senders));
                }

                
                if (_getCodeDto == null)
                {
                    return NoContent();
                }

                return Ok(_getCodeDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }


        }

        [HttpPut("{Id:int}")]
        [ProducesResponseType(201, Type = typeof(BranchOfficesPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, [FromBody] SendersPUTDto modelDto)
        {

            try
            {
                if (Id != modelDto.SenderId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN REMITENTE");

                var get = await _logisticaService.GetSendersByIdAsync(modelDto.SenderId!);
                if (get == null)
                    return BadRequest();
                _mapper.Map(modelDto, get);

                get.IsAsset = true;
                get.IsCreadSender = null;
                get.IsDeleted = false;
                get.IsDeletedAt = null;
                get.IsModifiedPostalCode = true;
                get.IsModifiedSender = true;
                get.IsDeletedAt = null;
                get.IsModifiedSenderDate = DateTime.Now;

                if (!await _logisticaService.SaveAll())
                    return NoContent();

                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }
    }
}
