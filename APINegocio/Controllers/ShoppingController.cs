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
    public class ShoppingController : ControllerBase
    {
        private readonly ILogisticaService _LogiticaServices;
        private readonly IMapper _Mapper;

        public ShoppingController(ILogisticaService logisticaService, IMapper mapper)
        {
            _LogiticaServices = logisticaService;
            _Mapper = mapper;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedShopping = await _LogiticaServices.GetShoppingByIdAsync(id);
            if (deletedShopping == null)
                return NotFound("ERROR!... LA COMPRA QUE DESEA ELIMINAR NO FUE ENCONTRADO");

            _LogiticaServices.Remove(deletedShopping);
            if (!await _LogiticaServices.SaveAll())
                return BadRequest("ERROR!... ESTA COMPRA NO SE PUEDE ELIMINAR");

            return Ok("LA COMPRA FUE ELIMINADA, SATISFACTORIAMENTE");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var get = await _LogiticaServices.GetShoppings();
            return Ok(get);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getById = await _LogiticaServices.GetShoppingByIdAsync(Id);
            if (getById == null)
                return NotFound("ERROR!.. LA COMPRA NO FUE ENCONTRADO");

            return Ok(getById);

        }

        [HttpGet("number/{number}")]
        public async Task<IActionResult> Get(Shopping model)
        {
            var getNumber = await _LogiticaServices.GetShoppingByNumberShopping(model);
            if (getNumber == null)
                return NotFound("COMPRA NO ENCONTRADA " + "VERIFIQUE SI EL NUMERO DE LA COMPRA ES VALIDO");

            return Ok(getNumber);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetCode(Shopping model)
        {
            var getCode = await _LogiticaServices.GetShoppingByCodeAsync(model);
            if (getCode is null)
                return NotFound("COMPRA NO ENCONTRADA" + "VERIFIQUE SI EL CODIGO ES VALIDO");

            return Ok(getCode);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShoppingPOSTDto model)
        {
            var post = _Mapper.Map<Shopping>(model);

            _LogiticaServices.Add(post);

            if (await _LogiticaServices.SaveAll())
                return Ok(post);
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, ShoppingPUTDto model) 
        {
         if(Id != model.ShoppingId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUNA COMPRA");

         var get = await _LogiticaServices.GetShoppingByIdAsync(model.ShoppingId);
            if (get is null)
                return BadRequest();

            _Mapper.Map(get, model);

            if(!await _LogiticaServices.SaveAll())
                return NoContent();

            return Ok(get);
        }
    }
}
