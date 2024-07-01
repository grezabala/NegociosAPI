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
        private readonly ILocationService _LocationService;
        private readonly IMapper Mapper;

        public StoresController(ILocationService locationService, IMapper mapper)
        {
            _LocationService = locationService;
            Mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getStores = await _LocationService.GetStores();
            return Ok(getStores);
        }

        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int Id)
        {
            var getByIdStore = await _LocationService.GetByIdStoresAsync(Id);
            if (getByIdStore == null)
                return BadRequest("ERROR!" + "LA TIENDA QUE BUSCA NO FUE ENCONTRADA");
            return Ok(getByIdStore);
        }

      
        [AllowAnonymous]  
        [HttpGet("name/{name}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Stores names)
        {
            var getByNameStore = await _LocationService.GetByNameStoresAsync(names.StoresName);
            if (getByNameStore == null)
                return BadRequest("ERROR" + "EL NOMBRE QUE INGRESASTE NO SE ENCUENTRA REGISTRADO COMO TIENDA");

            return Ok(getByNameStore);

        }

        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            var getByIdStor = await _LocationService.GetByIdStoresAsync(Id);
            if (getByIdStor == null)
                return NotFound("ERROR!" + "LA TIENDA NO FUE ENCONTRADA O YA NO EXISTE");

            _LocationService.GetByStoreIsDeleted(getByIdStor);
            if (!await _LocationService.SaveAll())
                return BadRequest("ERROR!" + "NO ES POSIBLE ELIMINAR ESTA TIENDA");

            return Ok(getByIdStor);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(StoresPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> POST([FromBody] StoresPOSTDto modelDto)
        {

            var addStor = Mapper.Map<Stores>(modelDto);

            _LocationService.Add(addStor);

            if (await _LocationService.SaveAll())
                return Ok(addStor);
            return BadRequest("ERROR!");
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(StoresPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PUT(int Id, [FromBody] StoresPUTDto modelDto) 
        {
          
            if(Id != modelDto.StoresId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUNA TIENDA");

            var getId = await _LocationService.GetByIdStoresAsync(modelDto.StoresId);
            if (getId == null)
                return BadRequest();

            Mapper.Map(modelDto, getId);

            if (!await _LocationService.SaveAll())
                return NoContent();

            return Ok(getId);
        }
    }
}
