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
    public class TickersController : ControllerBase
    {
        private readonly ILogisticaService _LogisticaService;
        private readonly IMapper Mapper;

        public TickersController(ILogisticaService logisticaService, IMapper mapper)
        {
            _LogisticaService = logisticaService;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getTicker = await _LogisticaService.GetTickers();
            return Ok(getTicker);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getTickerById = await _LogisticaService.GetTickersByIdAsync(Id);
            if (getTickerById == null)
                return BadRequest("ERROR! " + "EL TICKER NO SE ENCONTRO...");

            return Ok(getTickerById);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(Tickers model)
        {
            var getTikerByName = await _LogisticaService.GetTickersByNameAsync(model.TickerTitulo);

            if (getTikerByName is null)
                return BadRequest("ERROR! " + "NO SE ENCONTRO EL TICKER");

            return Ok(getTikerByName);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Deleted(int Id)
        {
            var deletedTicker = await _LogisticaService.GetTickersByIdAsync(Id);
            if (deletedTicker == null)
                return NotFound("ERROR! " + "EL TICKER NO FUE ELIMINADO");

            _LogisticaService.Remove(deletedTicker);
            if (!await _LogisticaService.SaveAll())
                return BadRequest("ERROR!... NO SE PUDO ELIMINAR EL TICKER");

            return Ok("EL TICKER FUE ELIMINADO CORRECTAMENTE");
        }

        [HttpPost]
        public async Task<IActionResult> POST(TickersPOSTDto modelDto)
        {
            var postTicker = Mapper.Map<Tickers>(modelDto);
            _LogisticaService.Add(postTicker);

            if (await _LogisticaService.SaveAll())
                return Ok(postTicker);
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PUT(int Id, TickersPUTDto modelDto)
        {
            if (Id != modelDto.TickerId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN TICKER");
            var putTiker = await _LogisticaService.GetTickersByIdAsync(modelDto.TickerId);
            if (putTiker == null)
                return BadRequest();

            Mapper.Map(putTiker, modelDto);

            if (!await _LogisticaService.SaveAll())
                return NoContent();

            return Ok(putTiker);
        }
    }
}
