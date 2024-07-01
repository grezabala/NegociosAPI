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
    //[Authorize]
    public class TickersController : ControllerBase
    {
        private readonly ITickersService _tickerServices;
        private readonly IMapper _mapper;

        public TickersController(ITickersService tickersService, IMapper mapper)
        {
            _tickerServices = tickersService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _getTicker = await _tickerServices.GetTickers();
                var listDto = new List<TickersDto>();
                foreach (var _tickers in _getTicker)
                {

                    listDto.Add(_mapper.Map<TickersDto>(_tickers));
                }
                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No fue posible mostrar todos los Tickers emitidos", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int Id)
        {
            try
            {
                var getTickerById = _tickerServices.GetTickersById(Id);

                if (getTickerById == null)
                    return NotFound("ERROR! " + "EL TICKER NO SE ENCONTRO...");

                var listDto = new List<TickersDto>(getTickerById.TickerId);

                return Ok(getTickerById);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay ningún ticker emitido con ese ID, por favor validar que el ID es el correcto", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetByTickerNIF")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTickerNIF(int nif)
        {
            try
            {
                var _getTickerByNIF = await _tickerServices.GetByTickersNIFAsync(nif);
                if (_getTickerByNIF == null)
                    return BadRequest("ERROR! " + "EL TICKER NO SE ENCONTRO...");

                var listDto = new List<TickersDto>();
                foreach (var ticker in _getTickerByNIF)
                {
                    listDto.Add(_mapper.Map<TickersDto>(ticker));
                }

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay ningún ticker emitido con ese NIF, por favor validar que el NIF es el correcto", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetByTickerRNC")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTickerRNC(int rnc)
        {
            try
            {
                var getTickerByRNC = await _tickerServices.GetByTickersRNCAsync(rnc);
                if (getTickerByRNC == null)
                    return NotFound("ERROR! " + "EL TICKER NO SE ENCONTRO...");

                var listDto = new List<TickersDto>();
                foreach (var tickers in getTickerByRNC)
                {
                    listDto.Add(_mapper.Map<TickersDto>(tickers));
                }

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay ningún ticker emitido con ese NIF, por favor validar que el NIF es el correcto", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("Dia")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTickerDate(DateTime dia)
        {
            try
            {
                var getDateTicker = await _tickerServices.GetByTickersDateAsync(dia);
                if (getDateTicker == null)
                    return NotFound("ERROR! " + "EL TICKER NO SE ENCONTRO...");

                var listDto = new List<TickersDto>();
                foreach (var ticker in getDateTicker)
                {

                    listDto.Add(_mapper.Map<TickersDto>(ticker));

                }

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay ningún ticker emitido con el día, por favor validar que la fecha sea correcto", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetByTickerName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTickerName(string titulo)
        {
            try
            {
                var getTikerByName = await _tickerServices.GetTickersByNameAsync(titulo);

                if (getTikerByName == null)
                    return NotFound("ERROR! " + "NO SE ENCONTRO EL TICKER");

                var listDto = new List<TickersDto>();

                foreach (var tickers in getTikerByName)
                {
                    listDto.Add(_mapper.Map<TickersDto>(tickers));
                }

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salió mal al mostrar el ticker", ex);
            }


        }

        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Deleted(int Id)
        {
            try
            {
                var deletedTicker = _tickerServices.GetTickersById(Id);
                if (deletedTicker == null)
                    return NotFound("ERROR! " + "EL TICKER NO FUE ELIMINADO");

                if (!_tickerServices.GetByTickersIsDeleted(deletedTicker))
                {
                    ModelState.AddModelError("", "Error! No fue posible eliminar el Ticker");
                    return StatusCode(500, ModelState);

                }

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salió mal al eliminar el Ticker", ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TickersPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> POST([FromBody] TickersPOSTDto modelDto)
        {
            try
            {
                if (ModelState.IsValid)
                    return BadRequest(ModelState);

                if (modelDto == null)
                    return BadRequest(ModelState);

                if (_tickerServices.IsExisteByTickersRNC(modelDto.RNC))
                {
                    ModelState.AddModelError("", "Error! El Ticker ya se encuentra registrado, por lo tanto ya fue emitidos");
                    return StatusCode(404, ModelState);

                }

                if (_tickerServices.IsExisteByTickersNIF(modelDto.NIF)) 
                {
                    ModelState.AddModelError("", "Error! El Ticker ya se encuentra registrado, por lo tanto ya fue emitidos");
                    return StatusCode(404, ModelState);

                }

                var postTickers = _mapper.Map<Tickers>(modelDto);

                if (!_tickerServices.IsCreadAsync(postTickers)) 
                {
                  return Ok(postTickers);
                }

                return Ok(postTickers);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salió mal al registrar el nuevo Ticker", ex);
            }

            //var postTicker = Mapper.Map<Tickers>(modelDto);
            //_LogisticaService.Add(postTicker);

            //if (await _LogisticaService.SaveAll())
            //    return Ok(postTicker);
            //return BadRequest();
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(TickersPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PUT(int Id, [FromBody] TickersPUTDto modelDto)
        {

            try
            {
                if (Id != modelDto.TickerId)
                    return BadRequest("Error! No se encontro ningún Ticker con ese ID");

                var putTicker = _tickerServices.GetTickersById(Id);

                if (putTicker == null)
                    return BadRequest();

                _mapper.Map(modelDto, putTicker);

                if(!_tickerServices.IsSaveAll())
                        return BadRequest();

                return Ok(putTicker);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salió mal al modificar el ticker",ex);
            }


            //if (Id != modelDto.TickerId)
            //    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN TICKER");
            //var putTiker = await _LogisticaService.GetTickersByIdAsync(modelDto.TickerId);
            //if (putTiker == null)
            //    return BadRequest();

            //Mapper.Map(putTiker, modelDto);

            //if (!await _LogisticaService.SaveAll())
            //    return NoContent();

            //return Ok(putTiker);
        }
    }
}
