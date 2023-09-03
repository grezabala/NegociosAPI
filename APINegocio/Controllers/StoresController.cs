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
    public class StoresController : ControllerBase
    {
        private readonly ILocationService _LocationService;
        private readonly IMapper Mapper;

        public StoresController(ILocationService locationService, IMapper mapper)
        {
            _LocationService = locationService;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getStores = await _LocationService.GetStores();
            return Ok(getStores);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getByIdStore = await _LocationService.GetByIdStoresAsync(Id);
            if (getByIdStore == null)
                return BadRequest("ERROR!" + "LA TIENDA QUE BUSCA NO FUE ENCONTRADA");
            return Ok(getByIdStore);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(Stores names)
        {
            var getByNameStore = await _LocationService.GetByNameStoresAsync(names.StoresName);
            if (getByNameStore == null)
                return BadRequest("ERROR" + "EL NOMBRE QUE INGRESASTE NO SE ENCUENTRA REGISTRADO COMO TIENDA");

            return Ok(getByNameStore);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var getByIdStor = await _LocationService.GetByIdStoresAsync(Id);
            if (getByIdStor == null)
                return NotFound("ERROR!" + "LA TIENDA NO FUE ENCONTRADA O YA NO EXISTE");

            _LocationService.Remove(getByIdStor);
            if (!await _LocationService.SaveAll())
                return BadRequest("ERROR!" + "NO ES POSIBLE ELIMINAR ESTA TIENDA");

            return Ok(getByIdStor);

        }

        [HttpPost]
        public async Task<IActionResult> POST(StoresPOSTDto modelDto)
        {

            var addStor = Mapper.Map<Stores>(modelDto);

            _LocationService.Add(addStor);

            if (await _LocationService.SaveAll())
                return Ok(addStor);
            return BadRequest("ERROR!");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PUT(int Id, StoresPUTDto modelDto) 
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
