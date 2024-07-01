using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Data.Services.Repository;
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
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        //[AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize]
        public async Task<IActionResult> GetInventory()
        {
            try
            {
                var _getInventario = await _inventoryService.GetInventoryAsync();
                var listDto = new List<InventoryDto>();

                foreach (var inventory in _getInventario)
                {
                    listDto.Add(_mapper.Map<InventoryDto>(inventory));
                
                }

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }

        }

        //[AllowAnonymous]
        [HttpGet("Id/{Id:int}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int Id)
        {

            try
            {
                var getById = await _inventoryService.GetByInventoryId(Id);
                if (getById == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESE ID");
                return Ok(getById);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }

        }

        //[AllowAnonymous]
        [HttpGet("~/GetInventoryByNumber")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public async Task<IActionResult> GetInventoryByNumber(int number)
        {

            try
            {
                var getNumber = await _inventoryService.GetByInventoriesNumber(number);
                if (getNumber == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESTE NUMERO");

                return Ok(getNumber);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //[AllowAnonymous]
        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public async Task<IActionResult> GetName(string name)
        {

            try
            {
                var getName = await _inventoryService.GetByInventoryName(name);
                if (getName == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESTE NOMBRE");

                return Ok(getName);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //[AllowAnonymous]
        [HttpGet("code/{code}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public async Task<IActionResult> GetCode(string code)
        {
            try
            {
                var getCode = await _inventoryService.GetByCodeInventory(code);
                if (getCode == null)
                    return NotFound("ERROR! NO SE ENCONTRO NINGUN INVENTARIO ASOCIADO A ESTE CODIGO");

                return Ok(getCode);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<IActionResult> Deleted(int Id)
        {
            try
            {
                var getDeleted = await _inventoryService.GetByInventoryId(Id);
                if (getDeleted == null)
                    return NotFound("ERROR!... EL PRODUCTO QUE DESEA ELIMINAR NO FUE INVENTARIO");

                var _deleted = _inventoryService.GetByInventoryId(Id);
                if (!await _inventoryService.IsDeleted(await _deleted))
                    return BadRequest("ERROR!... NO SE PUDO ELIMINAR EL INVENTARIO");

                return Ok("INVENTARIO ELIMINADO CORRECTAMENTE");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(InventoryPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<IActionResult> POST(InventoryPOSTDto pOSTDto)
        {
            if (_inventoryService.IsExisteGetInventarioByCode(pOSTDto.CodigoInventory))
                return BadRequest("Este Inventario ya fue registrado");

            if (_inventoryService.IsExisteGetInventarioByNumber(pOSTDto.NumberInventory))
                return BadRequest("Este Inventario ya existe");

            var add = _mapper.Map<Inventory>(pOSTDto);

            if (!_inventoryService.IsCread(add))
            {
                ModelState.AddModelError("", "Algo salió mal al registrar el nuevo Inventarios");
                StatusCode(500, ModelState);
            }

            return Ok(add);
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(InventoryPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<IActionResult> PUT(int Id, [FromBody] InventoryPUTDto pUTDto)
        {
            try
            {
                if (Id != pUTDto.InventoryId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN INVENTARIO");

                var getInventario = await _inventoryService.GetByInventoryId(pUTDto.InventoryId);

                if (getInventario is null)
                    return BadRequest("NO SE ENCONTRO NINGUN INVENTARIO");

                _mapper.Map(pUTDto, getInventario);

                if (_inventoryService.IsSaveAll())
                    return NoContent();

                return Ok(getInventario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
