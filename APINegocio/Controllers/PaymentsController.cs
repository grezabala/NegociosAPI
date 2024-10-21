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

        private readonly ILogisticaService _logisticaService;

        private readonly IMapper _mapper;

        public PaymentsController(ILogisticaService logisticaService, IMapper mapper)
        {
            _logisticaService = logisticaService;
            _mapper = mapper;
        }

        // GET: api/<PaymentsController>
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPayments()
        {
            try
            {
                var _get = await _logisticaService.GetPayments();
                var _getDtos = new List<PaymentsDto>();

                foreach (var payments in _get) 
                {
                    _getDtos.Add(_mapper.Map<PaymentsDto>(payments));
                
                }

                return Ok(_getDtos);

                //var get = await _logisticaService.GetPayments();
                //if (get == null)
                //    return NotFound();

                //return Ok(get);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Al cargar los pagos.", ex);
            }


        }

        // GET api/<PaymentsController>/5
        [AllowAnonymous]
        [HttpGet("{Id:int}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaymentById(int Id)
        {
            try
            {
                var getById = await _logisticaService.GetPaymentsByIdAsync(Id);

                if (getById == null)
                    return NoContent();

                var getByIdDto = _mapper.Map<PaymentsDto>(getById);

                return Ok(getByIdDto);

                //if (getById == null)
                //    return BadRequest("ERROR!... EL PAGO QUE BUSCA NO SE HA REGISTRADO");

                //return Ok(getById);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el pago, verificar el ID si esta correctamente.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetPaymentByCode")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaymentByCode(string code)
        {
            try
            {
                var _get = await _logisticaService.GetPaymentsByCodeAsync(code);
                if (_get == null)
                    return BadRequest("ERROR!... EL PAGO QUE BUSCA NO SE HA REGISTRADO");

                var listDto = _mapper.Map<PaymentsDto>(_get);

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el pago, verificar el ID si esta correctamente.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetPaymentByToquen")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaymentByToquen(string toquen)
        {
            try
            {
                var _get = await _logisticaService.GetPaymentsByToquenAsync(toquen);
                if (_get == null)
                    return BadRequest("ERROR!... EL PAGO QUE BUSCA NO SE HA REGISTRADO");

                var listDto = _mapper.Map<PaymentsDto>(_get);

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el pago, verificar el ID si esta correctamente.", ex);
            }

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
            try
            {
                var addPayment = _mapper.Map<Payments>(modelDto);

                addPayment.IsDeleted = false;
                addPayment.IsDeletedAt = null;
                addPayment.IsCreadtPayment = DateTime.Now;
                addPayment.IsStatud = true;
                addPayment.IsCreadtRefund = false;
                addPayment.IsRefund = false;
                addPayment.IsUpdated = false;
                addPayment.IsUpdatedAt = null;
                addPayment.Fecha = DateTime.Now;

                _logisticaService.Add(addPayment);

                if (!await _logisticaService.SaveAll())
                    return Ok(addPayment);

                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible cargar el pago.", ex);
            }

        }

        // PUT api/<PaymentsController>/5
        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(PaymentsPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, [FromBody] PaymentsPUTDto modelDto)
        {
            try
            {
                if (Id != modelDto.PaymentId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN PAGO");

                var updatePayment = await _logisticaService.GetPaymentsByIdAsync(Id);

                if (updatePayment == null)
                    return BadRequest();

                _mapper.Map(modelDto, updatePayment);

                updatePayment.IsDeleted = false;
                updatePayment.IsDeletedAt = null;
                updatePayment.IsCreadtPayment = null;
                updatePayment.IsStatud = true;
                updatePayment.IsCreadtRefund = false;
                updatePayment.IsRefund = false;
                updatePayment.IsUpdated = true;
                updatePayment.IsUpdatedAt = DateTime.Now;

                if (!await _logisticaService.SaveAll())
                    return NotFound();

                return Ok(updatePayment);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible editar el pago.", ex);
            }

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
            try
            {
                var deleted = await _logisticaService.GetPaymentsByIdAsync(Id);

                if (deleted == null)
                    return NotFound("ERROR!... EL PAGO QUE DESEA ELIMINAR NO FUE ENCONTRADO");

                if (_logisticaService.GetByPaymentIsDeleted(deleted)) 
                {
                    ModelState.AddModelError("", "Error...! No fue posible eliminar el pago");
                    StatusCode(500, ModelState);
                
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible eliminar el pago.", ex);
            }

        }
    }
}
