using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ILogisticaService _LogiticaServices;
        private readonly IMapper _Mapper;

        public CustomersController(ILogisticaService logiticaServices, IMapper mapper)
        {
            _LogiticaServices = logiticaServices;
            _Mapper = mapper;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Deleted(int Id)
        {
            var deletedCustomer = await _LogiticaServices.GetCustomersByIdAsync(Id);
            if (deletedCustomer is null)
                return BadRequest("ERROR!... EL ID DEL CLIENTE NO FUE ENCONTRADO");

            _LogiticaServices.Remove(deletedCustomer);
            if (!await _LogiticaServices.SaveAll())
                return BadRequest("ERROR!... NO FUE POSIBLE ELIMINAR EL CLIENTE");

            return Ok("EL CLIENTE FUE ELIMINADO CORRECTAMENTE");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getCustomer = await _LogiticaServices.GetCliente();
            return Ok(getCustomer);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getCustomerById = await _LogiticaServices.GetCustomersByIdAsync(Id);
            if (getCustomerById is null)
                return NotFound("ERROR! EL CLIENTE NO FUE ENCONTRADO");

            return Ok(getCustomerById);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(Customers model) 
        {
            var getCustomerName = await _LogiticaServices.GetCustomersByNameAsync(model.CustomerName);
            if (getCustomerName == null)
                return NotFound("ERROR!... EL NOMBRE DEL FUE CLIENTE ENCONTRADO");

            return Ok(getCustomerName);
        }


        [HttpPost]
        public async Task<IActionResult> POST(CustomerPOSTDto modelDto)
        {
            var postCustomer = _Mapper.Map<Customers>(modelDto);
            _LogiticaServices.Add(postCustomer);

            if (await _LogiticaServices.SaveAll())
                return Ok(postCustomer);
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PUT(int Id, CustomerPUTDto modelDto)
        {
            if (Id != modelDto.CustomerId)
                return BadRequest("ERROR!... EL ID QUE HAZ INGRESADO NO EXISTE");

            var putCustomer = await _LogiticaServices.GetCustomersByIdAsync(modelDto.CustomerId!);
            if (putCustomer is null)
                return BadRequest();

            _Mapper.Map(modelDto, putCustomer);

            if(!await _LogiticaServices.SaveAll())
                return BadRequest("EL CLIENTE HAZ SIDO MODIFICADO CORRECTAMENTE");

            return Ok(putCustomer);
        }
    }
}
