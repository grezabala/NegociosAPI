using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CityController : ControllerBase
    {
        private readonly ILocationService _LocationService;
        private readonly IMapper Mapper;

        public CityController(ILocationService locationService, IMapper mapper)
        {
            _LocationService = locationService;
            Mapper = mapper;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getCity = await _LocationService.GetCitys();
            if (getCity == null)
                return NotFound("ERROR!... AL MOSTRAR LAS CIUDADES");

            return Ok(getCity);
        }

        // GET api/<CityController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getByIdCity = await _LocationService.GetByIdCityAsync(Id);
            if (getByIdCity == null)
                return NotFound("ERROR!... EL ID DEL LA CIUDAD NO EXISTE");

            return Ok(getByIdCity);
        }

        // GET api/<CityController>/5
        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(City name)
        {
            var getByNameCity = await _LocationService.GetByNameCityAsync(name.CityName);
            if (getByNameCity == null)
                return NotFound("ERROR!... EL ID DEL LA CIUDAD NO EXISTE");

            return Ok(getByNameCity);
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CityPOSTDto modelDto)
        {
            var addCity = Mapper.Map<City>(modelDto);

            _LocationService.Add(addCity);

            if (await _LocationService.SaveAll())
                return Ok(addCity);
            return BadRequest();
        }

        // PUT api/<CityController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] CityPUTDto modelDto)
        {
            if (Id != modelDto.CityId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUNA CIUDAD");

            var updateCity = await _LocationService.GetByIdCityAsync((int)modelDto.CityId);

            if (updateCity == null)
                return BadRequest();

            Mapper.Map(modelDto, updateCity);

            if (!await _LocationService.SaveAll())
                return NoContent();

            return Ok(updateCity);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deletedCity = await _LocationService.GetByIdCityAsync(Id);
            if (deletedCity == null)
                return NotFound("ERROR!... EL ID DE LA CIUDAD QUE NO FUE ENCONTRADO");

            _LocationService.Remove(deletedCity);
            if (!await _LocationService.SaveAll())
                return BadRequest("EROOR!... NO FUE POSIBLE ELIMINAR ESTA CIUDAD");

            return Ok("ESTA CIUDAD FUE ELIMINADA");
        }
    }
}
