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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class OrdersController : ControllerBase
    {
        private readonly ILogisticaService _logisticaService;
        private readonly IMapper _mapper;

        public OrdersController(ILogisticaService logisticaService, IMapper mapper)
        {
            _logisticaService = logisticaService;
            _mapper = mapper;
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Deleted(int Id)
        {
            try
            {
                var deleteOrder = await _logisticaService.GetOrdersByIdAsync(Id);
                if (deleteOrder == null)
                    return NotFound("ERROR!... EL PEDIDO QUE DESEA ELIMINAR NO FUE ENCONTRADO");


                if (_logisticaService.GetByOrderIsDeleted(deleteOrder))
                {
                    ModelState.AddModelError("", "Error...! Al eliminar la Orden");
                    StatusCode(500, ModelState);
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible eliminar el registro.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var getOrder = await _logisticaService.GetOrders();
                var getOrderDto = new List<OrdersDto>();


                foreach (var orders in getOrder)
                {
                    getOrderDto.Add(_mapper.Map<OrdersDto>(orders));
                }

                if (getOrderDto == null)
                    return NotFound("LOS PEDIDOS NO FUERON ENCONTRADO " + "POR FAVOR CONTACTAR A TI");

                return Ok(getOrderDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar todas las Ordenes.", ex);
            }


        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(OrdersPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> POST(OrdersPOSTDto modelDto)
        {
            try
            {
                var post = _mapper.Map<Orders>(modelDto);

                post.IsDeleted = false;
                post.IsCreadOrderDate = DateTime.Now;
                post.DateOrder = DateTime.Now;
                post.IsAsset = true;
                post.IsModified = false;
                post.IsModifiedOrderDate = null;
                post.IsDeletedAt = null;

                _logisticaService.Add(post);


                if (await _logisticaService.SaveAll())
                    return Ok(post);
                return BadRequest();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible registrar la nueva Orden.", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderById(int Id)
        {
            try
            {
                var getByIdOrder = await _logisticaService.GetOrdersByIdAsync(Id);
                var getByIdOrderDto = _mapper.Map<OrdersDto>(getByIdOrder);


                if (getByIdOrderDto == null)
                    return NotFound("ERROR!... EL PEDIDO NO FUE ENCONTRADO");

                return Ok(getByIdOrderDto);

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar la Orden, por favor verificar si el ID esta correcto.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{name}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderByName(string model)
        {
            try
            {
                var getNameOrder = await _logisticaService.GetOrdersByNameAsync(model);
                var getNameOrderDto = _mapper.Map<OrdersDto>(getNameOrder);


                if (getNameOrderDto == null)
                    return NotFound("ERROR!... EL NOMBRE DEL PEDIDO NO FUE ENCONTRADO " +
                        "POR FAVOR VERIFIQUE QUE HAYA REALIZADO EL PEDIDO");

                return Ok(getNameOrderDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar la Orden, por favor verificar si el nombre esta correcto.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("code/{code}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCode(string code)
        {
            try
            {
                var getCodeOrder = await _logisticaService.GetOrdersByCodeAsync(code);
                var getCodeOrderDto = _mapper.Map<OrdersDto>(getCodeOrder);

                if (getCodeOrderDto == null)
                    return NotFound("ERROR!... EL CODIGO DEL PEDIDO NO FUE ENCONTRADO " +
                        "POR FAVOR VERIFIQUE QUE HAYA REALIZADO EL PEDIDO");

                return Ok(getCodeOrderDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar la Orden, por favor verificar si el código esta correcto.", ex);
            }

        }

        [HttpPut("Id/{Id:int}")]
        [ProducesResponseType(201, Type = typeof(BranchOfficesPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PUT(int Id, OrdersPUTDto modelDto)
        {
            try
            {
                if (Id != modelDto.OrderId!)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN PRODUCTO");

                var updatedOrder = await _logisticaService.GetOrdersByIdAsync(modelDto.OrderId);

                if (updatedOrder == null)
                    return BadRequest();

                _mapper.Map(modelDto, updatedOrder);

                updatedOrder.IsDeleted = false;
                updatedOrder.IsCreadOrderDate = null;
                updatedOrder.DateOrder = null;
                updatedOrder.IsAsset = true;
                updatedOrder.IsModified = false;
                updatedOrder.IsModifiedOrderDate = DateTime.Now;
                updatedOrder.IsDeletedAt = null;

                if (!await _logisticaService.SaveAll())
                    return NoContent();

                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al modificar la Orden, por favor intentarlo de nuevo.", ex);
            }

        }
    }
}
