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
    public class CountriesController : ControllerBase
    {
        private readonly ILocationService _LocationService;
        private readonly IMapper Mapper;

        public CountriesController(ILocationService locationService, IMapper mapper)
        {
            _LocationService = locationService;
            Mapper = mapper;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getCountry = await _LocationService.GetCountries();
            if (getCountry == null)
                return NotFound();

            return Ok(getCountry);
        }

        // GET api/<CountriesController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getByIdCountry = await _LocationService.GetByIdCountriesAsync(Id);
            if (getByIdCountry == null)
                return BadRequest();

            return Ok(getByIdCountry);
        }

        // GET api/<CountriesController>/5
        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(Countries name)
        {
            var getByNameCountry = await _LocationService.GetByNameCountrieAsync(name.CountryName);
            if (getByNameCountry == null)
                return BadRequest();

            return Ok(getByNameCountry);
        }

        // POST api/<CountriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountriesPOSTDto modelDto)
        {
            var addCountry = Mapper.Map<Countries>(modelDto);

            _LocationService.Add(addCountry);

            if (!await _LocationService.SaveAll())
                return Ok(addCountry);
            return BadRequest();

        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] CountriesPUTDto modelDto)
        {

            if(Id != modelDto.CountryId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN PAIS");

            var getByIdCountry = await _LocationService.GetByIdCountriesAsync(Id);
            if (getByIdCountry == null)
                return BadRequest();

            Mapper.Map(getByIdCountry, modelDto);

            if(await _LocationService.SaveAll())
                return NoContent();

            return Ok(getByIdCountry);
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var getById = await _LocationService.GetByIdCountriesAsync(Id);
            if(getById == null)
                return NotFound();

            _LocationService.Remove(getById);
            if(!await _LocationService.SaveAll())
                return BadRequest("ERROR!" + "NO ES POSIBLE ELIMINAR EL PAIS");
            return Ok(getById);

        }
    }
}
