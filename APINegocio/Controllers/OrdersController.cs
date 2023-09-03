using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINegocio.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
 
    public class OrdersController : ControllerBase
    {
        private readonly ILogisticaService _LogisticaService;
        private readonly IMapper _Mapper;

        public OrdersController(ILogisticaService logisticaService, IMapper mapper)
        {
            _LogisticaService = logisticaService;
            _Mapper = mapper;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Deleted(int Id)
        {
            var deleteOrder = await _LogisticaService.GetCustomersByIdAsync(Id);
            if (deleteOrder == null)
                return NotFound("ERROR!... EL PEDIDO QUE DESEA ELIMINAR NO FUE ENCONTRADO");

            _LogisticaService.Remove(deleteOrder);
            if (!await _LogisticaService.SaveAll())
                return BadRequest("ERROR!... NO SE PUDO ELIMINAR EL PEDIDO");

            return Ok("EL PEDIDO FUE ELIMINADO CORRECTAMENTE");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getOrder = await _LogisticaService.GetShoppings();
            if (getOrder == null)
                return NotFound("LOS PEDIDOS NO FUERON ENCONTRADO " + "POR FAVOR CONTACTAR A TI");

            return Ok(getOrder);

        }

        [HttpPost]
        public async Task<IActionResult> POST(OrdersPOSTDto modelDto) 
        {
            var post = _Mapper.Map<Orders>(modelDto);

            _LogisticaService.Add(post);

            if(await _LogisticaService.SaveAll())
                return Ok(post);
            return BadRequest();

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getByIdOrder = await _LogisticaService.GetCustomersByIdAsync(Id);
            if (getByIdOrder == null)
                return NotFound("ERROR!... EL PEDIDO NO FUE ENCONTRADO");

            return Ok(getByIdOrder);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetName(Orders model) 
        {
            var getNameOrder = await _LogisticaService.GetOrdersByNameAsync(model.OrderName!);
            if(getNameOrder == null)
                return NotFound("ERROR!... EL NOMBRE DEL PEDIDO NO FUE ENCONTRADO " + 
                    "POR FAVOR VERIFIQUE QUE HAYA REALIZADO EL PEDIDO");

            return Ok(getNameOrder);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetCode(Orders model) 
        {
            var getCodeOrder = await _LogisticaService.GetOrdersByCodeAsync(model.OrderCode!);
            if(getCodeOrder == null)
                return NotFound("ERROR!... EL CODIGO DEL PEDIDO NO FUE ENCONTRADO " + 
                    "POR FAVOR VERIFIQUE QUE HAYA REALIZADO EL PEDIDO");

            return Ok(getCodeOrder);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PUT(int Id, OrdersPUTDto modelDto) 
        {
            if (Id != modelDto.OrderId!)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN PRODUCTO");

            var updatedOrder = await _LogisticaService.GetOrdersByIdAsync(modelDto.OrderId);

            if (updatedOrder == null)
                return BadRequest();

            _Mapper.Map(modelDto, updatedOrder);

            if (!await _LogisticaService.SaveAll())
                return NoContent();

            return Ok(updatedOrder);

        }
    }
}
