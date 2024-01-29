using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Index.Strtree;

namespace APINegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly ILogisticaService _LogisticaService;
        private readonly IMapper Mapper;

        public InventoryController(ILogisticaService logisticaService, IMapper mapper)
        {
            _LogisticaService = logisticaService;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var get = await _LogisticaService.GetInventoryAsync();
                if (get == null)
                    return NotFound();
                return Ok(get);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Id/{Id}")]
        public async Task<IActionResult> Get([FromBody] int Id)
        {

            try
            {
                var getById = await _LogisticaService.GetByIdInventory(Id);
                if (getById == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESE ID");
                return Ok(getById);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("number/{number}")]
        public async Task<IActionResult> GetNumber([FromBody] int number)
        {

            try
            {
                var getNumber = await _LogisticaService.GetByNumberInventories(number);
                if (getNumber == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESTE NUMERO");

                return Ok(getNumber);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetName([FromBody] string name)
        {

            try
            {
                var getName = await _LogisticaService.GetByNameInventory(name);
                if (getName == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESTE NOMBRE");

                return Ok(getName);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetCode([FromBody] string code)
        {
            try
            {
                var getCode = await _LogisticaService.GetByCodeInventory(code);
                if (getCode == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESTE CODIGO");

                return Ok(getCode);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Deleted([FromBody] int Id)
        {
            try
            {
                var getDeleted = await _LogisticaService.GetByIdInventory(Id);
                if (getDeleted == null)
                    return NotFound("ERROR!... EL PRODUCTO QUE DESEA ELIMINAR NO FUE INVENTARIO");

                _LogisticaService.Remove(getDeleted);
                if (!await _LogisticaService.SaveAll())
                    return BadRequest("ERROR!... NO SE PUDO ELIMINAR EL INVENTARIO");

                return Ok("INVENTARIO ELIMINADO CORRECTAMENTE");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> POST(InventoryPOSTDto pOSTDto)
        {

            var add = Mapper.Map<Inventory>(pOSTDto);
            _LogisticaService.Add(add);

            if (await _LogisticaService.SaveAll())
                return Ok(add);
            return BadRequest();

            //try
            //{

            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}

        }

        [HttpPut("Id")]
        public async Task<IActionResult> PUT(int Id, [FromBody] InventoryPUTDto pUTDto)
        {
            try
            {
                if (Id != pUTDto.InventoryId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN INVENTARIO");

                var getInventario = await _LogisticaService.GetByIdInventory(pUTDto.InventoryId);

                if (getInventario is null)
                    return BadRequest("NO SE ENCONTRO NINGUN INVENTARIO");

                Mapper.Map(getInventario, pUTDto);

                if (!await _LogisticaService.SaveAll())
                    return NotFound("ERROR! AL GUARDAR LOS CAMBIOS");

                return Ok(getInventario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}
