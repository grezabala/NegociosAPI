using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {

        private readonly ILogisticaService _LogisticaService;

        private readonly IMapper Mapper;

        public PaymentsController(ILogisticaService logisticaService, IMapper mapper)
        {
            _LogisticaService = logisticaService;
            Mapper = mapper;
        }

        // GET: api/<PaymentsController>
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var get = await _LogisticaService.GetPayments();
            if(get == null)
                return NotFound();
            return Ok(get);
           
        }

        // GET api/<PaymentsController>/5
        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int Id)
        {
            var getById = await _LogisticaService.GetPaymentsByIdAsync(Id);
            if(getById == null)
                return BadRequest("ERROR!... EL PAGO QUE BUSCA NO SE HA REGISTRADO");
            return Ok(getById);
        }

        // POST api/<PaymentsController>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PaymentsPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] PaymentsPOSTDto modelDto)
        {
            var addPayment = Mapper.Map<Payments>(modelDto);
            _LogisticaService.Add(addPayment);

            if (!await _LogisticaService.SaveAll())
                return Ok(addPayment);
            return BadRequest();
        }

        // PUT api/<PaymentsController>/5
        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(PaymentsPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, [FromBody] PaymentsPUTDto modelDto)
        {
            if(Id != modelDto.PaymentId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN PAGO");

            var updatePayment = await _LogisticaService.GetPaymentsByIdAsync(Id);

            if (updatePayment == null)
                return BadRequest();

            if (!await _LogisticaService.SaveAll())
                return NotFound();

            return Ok(updatePayment);
        }

        // DELETE api/<PaymentsController>/5
        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleted = await _LogisticaService.GetPaymentsByIdAsync(Id);

            if(deleted == null)
                return NotFound("ERROR!... EL PAGO QUE DESEA ELIMINAR NO FUE ENCONTRADO");

            _LogisticaService.Remove(deleted);
            if(await _LogisticaService.SaveAll())
                return BadRequest("ERROR!... NO SE PUDO ELIMINAR EL PAGO");

            return  Ok("EL PAGO FUE ELIMINADO CORRECTAMENTE");
        }
    }
}
