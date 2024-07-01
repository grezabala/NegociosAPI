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
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;
        private readonly IMapper _mapper;

        public ShoppingController(IShoppingService shoppingService, IMapper mapper)
        {
            _shoppingService = shoppingService;
            _mapper = mapper;
        }

        [HttpDelete("Id/{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (!_shoppingService.IsExisteShoppingById(Id))
                {
                    return NotFound("La compra no existe.....");
                }


                var deletedShopping = await _shoppingService.GetShoppingByIdAsync(Id);
                //if (deletedShopping == null)
                //    return NotFound("ERROR!... LA COMPRA QUE DESEA ELIMINAR NO FUE ENCONTRADO");

                if (!_shoppingService.GetShoppingByIsDeleted(deletedShopping))
                {
                    ModelState.AddModelError("", $"Algo salió mal al eliminar su compra... {deletedShopping}");
                    return StatusCode(500, ModelState);

                }

                return Ok("LA COMPRA FUE ELIMINADA, SATISFACTORIAMENTE");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al eliminar su compra. Por favor validar que su compra existe.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShopping()
        {
            try
            {
                var _getShopping = await _shoppingService.GetShoppings();
                var _getShoppingDto = new List<ShoppingDto>();

                foreach (var shopping in _getShopping)
                {
                    _getShoppingDto.Add(_mapper.Map<ShoppingDto>(shopping));
                }

                return Ok(_getShoppingDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar todas las compra registrada.", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("~/GetShoppingById")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShoppingById(int Id)
        {
            try
            {
                var getById = await _shoppingService.GetShoppingByIdAsync(Id);

                var _getByIdDto = _mapper.Map<ShoppingDto>(getById);

                if (_getByIdDto == null)
                    return NotFound("ERROR!.. LA COMPRA NO FUE ENCONTRADO");

                return Ok(_getByIdDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar la compra. Por favor validar que el ID sea el correcto." + ":" +
                    "O que la compra existe.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetShoppingByNumber")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShoppingByNumber(int number)
        {
            try
            {
                var getNumber = await _shoppingService.GetShoppingByNumberShopping(number);

                var _getNumberDto = _mapper.Map<ShoppingDto>(getNumber);

                if (_getNumberDto == null)
                    return NotFound("COMPRA NO ENCONTRADA " + "VERIFIQUE SI EL NUMERO DE LA COMPRA ES VALIDO");

                return Ok(_getNumberDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar la compra. Por favor validar que el número sea el correcto." + ":" +
                    "O que la compra existe.", ex);
            }


        }


        [AllowAnonymous]
        [HttpGet("~/GetShoppingByCode")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShoppingByCode(string code)
        {
            try
            {
                var getCode = await _shoppingService.GetShoppingByCodeAsync(code);

                var _getCodeDto = _mapper.Map<ShoppingDto>(getCode);

                if (_getCodeDto is null)
                    return NotFound("COMPRA NO ENCONTRADA" + "VERIFIQUE SI EL CODIGO ES VALIDO");

                return Ok(_getCodeDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar la compra. Por favor validar que el código sea el correcto." + ":" +
                     "O que la compra existe.", ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ShoppingPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] ShoppingPOSTDto model)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (model == null)
                    return BadRequest(ModelState);

                if (_shoppingService.IsExisteShoppingByName(model.ShoppingName.ToLower().Trim()))
                {
                    ModelState.AddModelError("", "Error...! La compra ya existe." + ":" + "Desea duplicar la compra.");
                    return StatusCode(404, ModelState);

                }

                var post = _mapper.Map<Shopping>(model);

                if (!_shoppingService.IsCread(post))
                    return Ok(post);

                return Ok(post);

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al registrar su compra... por favor vuelva a intentarlo." + ":" +
                    "O verifique que esta registrando los datos solicitado correctamente.", ex);
            }

            //var post = _mapper.Map<Shopping>(model);

            // _shoppingService.IsCread(post);

            //if (await _shoppingService.IsSave())
            //    return Ok(post);
            //return BadRequest();
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(ShoppingPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, [FromBody] ShoppingPUTDto model)
        {
            try
            {
                if (Id != model.ShoppingId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUNA COMPRA");

                var get = await _shoppingService.GetShoppingByIdAsync(model.ShoppingId);

                if (get == null)
                    return BadRequest();

                _mapper.Map(model, get);

                if (!_shoppingService.IsSave())
                    return NoContent();

                return Ok(get);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al editar su compra... por favor vuelva a intentarlo." + ":" +
                    "O verifique que esta registrando los datos solicitado correctamente.", ex);
            }

        }
    }
}
