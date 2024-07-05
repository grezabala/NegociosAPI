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
    //[Authorize]
    public class StoresController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public StoresController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getStores = await _locationService.GetStores();
                var _getStoresDto = new List<StoresDto>();

                foreach (var stores in getStores)
                {
                    _getStoresDto.Add(_mapper.Map<StoresDto>(stores));
                }

                return Ok(_getStoresDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetStoresById")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStoresById(int Id)
        {
            try
            {
                var getByIdStore = await _locationService.GetByIdStoresAsync(Id);
                var getByIdStoreDto = _mapper.Map<StoresDto>(getByIdStore);

                if (getByIdStoreDto == null)
                {
                    return BadRequest("ERROR!" + "LA TIENDA QUE BUSCA NO FUE ENCONTRADA");
                }


                return Ok(getByIdStoreDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }


        [AllowAnonymous]
        [HttpGet("~/GetStoresByName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStoresByName(string names)
        {

            try
            {
                var getByNameStore = await _locationService.GetByNameStoresAsync(names);

                var getByNameStoreDto = _mapper.Map<StoresDto>(getByNameStore);

                if (getByNameStoreDto == null)
                {
                    return BadRequest("ERROR" + "EL NOMBRE QUE INGRESASTE NO SE ENCUENTRA REGISTRADO COMO TIENDA");
                }

                return Ok(getByNameStoreDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }


        }

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

                if (!_locationService.IsExisteStoresById(Id))
                {
                    return NotFound("LA TIENDA NO EXISTE, POR FAVOR VERIFICAR QUE LA TIENDA SE ENCUENTRE REGISTRADA");

                }
                var getByIdStor = await _locationService.GetByIdStoresAsync(Id);


                if (!_locationService.GetByStoreIsDeleted(getByIdStor))
                {
                    ModelState.AddModelError("", $"Error...! Algo salió mal al eliminar la tienda");
                    return StatusCode(404, ModelState);

                }


                return NotFound("Tienda eliminada correctamente!");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }


        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(StoresPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> POST([FromBody] StoresPOSTDto modelDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (modelDto == null)
                {
                    return BadRequest(ModelState);

                }

                if (_locationService.IsExisteStoresByName(modelDto.StoresName))
                {
                    ModelState.AddModelError("", "Error!");
                    return StatusCode(404, ModelState);

                }

                var addStor = _mapper.Map<Stores>(modelDto);

                if (!_locationService.IsCread(addStor)) 
                {
                
                    return Ok(addStor);
                }

                return Ok(addStor);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(StoresPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PUT(int Id, [FromBody] StoresPUTDto modelDto)
        {
            try
            {
                if (Id != modelDto.StorId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUNA TIENDA");

                var getId = await _locationService.GetByIdStoresAsync(modelDto.StorId);
                if (getId == null)
                    return BadRequest();

                _mapper.Map(modelDto, getId);

      
                if (!_locationService.IsUpdated(getId))
                    return NoContent();

                return Ok(getId);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }
    }
}
