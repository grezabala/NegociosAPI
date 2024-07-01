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

            //Agregar un el campo Código en la tabla Countries
        }


        // GET: api/<CountriesController>
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getCountry = await _LocationService.GetCountries();
            if (getCountry == null)
                return NotFound();

            return Ok(getCountry);
        }

        // GET api/<CountriesController>/5
        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int Id)
        {
            var getByIdCountry = await _LocationService.GetByIdCountriesAsync(Id);
            if (getByIdCountry == null)
                return BadRequest();

            return Ok(getByIdCountry);
        }

        // GET api/<CountriesController>/5
        [AllowAnonymous]
        [HttpGet("name/{name}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string name)
        {
            var getByNameCountry = await _LocationService.GetByNameCountrieAsync(name);
            if (getByNameCountry == null)
                return BadRequest();

            return Ok(getByNameCountry);
        }

        // POST api/<CountriesController>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CountriesPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] CountriesPOSTDto modelDto)
        {
            try
            {
                if (modelDto != null)
                {
                    var addCountry = Mapper.Map<Countries>(modelDto);

                    modelDto.IsDeleted = false;
                    modelDto.IsDeletedAt = null;
                    modelDto.IsStatud = true;
                    modelDto.IsUpdated = false;
                    modelDto.IsUpdatedAt = null;
                    modelDto.WhenDate = DateTime.Now;
                    modelDto.IsDateCreadCountry = DateTime.Now;

                    _LocationService.Add(addCountry);

                    if (!await _LocationService.SaveAll())
                    {
                        return Ok(addCountry);
                    }

                    if (addCountry == null)
                        return BadRequest();

                    return Ok(addCountry);
                }
                throw new InvalidOperationException("Error! El formulario se envio vacio, por favor introducir los datos correpondiente");
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salió mal al agregar el nuevo registro.", ex);
            }

        }

        // PUT api/<CountriesController>/5
        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(CountriesPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<IActionResult> Put(int Id, [FromBody] CountriesPUTDto modelDto)
        {

            try
            {
                if (Id != modelDto.CountryId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN PAIS");

                modelDto.IsDeleted = false;
                modelDto.IsDeletedAt = DateTime.Now.AddDays(-1);
                modelDto.IsUpdated = true;
                modelDto.IsUpdatedAt = DateTime.Now;

                var getByIdCountry = await _LocationService.GetByIdCountriesAsync(Id);

                if (getByIdCountry == null)
                    return BadRequest();

                Mapper.Map(modelDto, getByIdCountry);

                if (await _LocationService.SaveAll())
                    return NoContent();

                return Ok(getByIdCountry);
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible modificar el registro", ex);
            }


        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var getById = await _LocationService.GetByIdCountriesAsync(Id);
                if (getById == null)
                    return NotFound();

                _LocationService.GetByCountriesIsDeleted(getById);
                if (!await _LocationService.SaveAll())
                    return BadRequest("ERROR!" + "NO ES POSIBLE ELIMINAR EL PAIS");

                return Ok(getById);
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar el registro, por favor verificar que el Id es correcto", ex);
            }


        }
    }
}
