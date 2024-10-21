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
    //[Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public CountriesController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;

            //Agregar un el campo Código en la tabla Countries
        }


        // GET: api/<CountriesController>
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var getCountry = await _locationService.GetCountries();
                var _getCountryDto = new List<CountriesDto>();

                foreach (var country in getCountry)
                {
                    _getCountryDto.Add(_mapper.Map<CountriesDto>(country));
                }

                return Ok(_getCountryDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el listado de los paises.", ex);
            }

        }

        // GET api/<CountriesController>/5
        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountryById(int Id)
        {
            try
            {
                var getByIdCountry = await _locationService.GetByIdCountriesAsync(Id);

                var getByIdCountryDto = _mapper.Map<CountriesDto>(getByIdCountry);

                if (getByIdCountryDto == null)
                    return BadRequest();

                return Ok(getByIdCountryDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el país.", ex);
            }

        }

        // GET api/<CountriesController>/5
        [AllowAnonymous]
        [HttpGet("~/GetCountryByName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            try
            {
                var getByNameCountry = await _locationService.GetByNameCountrieAsync(name.ToLower().Trim());
                var getByNameCountryDto = _mapper.Map<CountriesDto>(getByNameCountry);

                if (getByNameCountryDto == null)
                    return BadRequest();

                return Ok(getByNameCountryDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el país. Por favor verificar que el nombre sea el correcto" + ":" +
                    "O que el país se encuentra registrado.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetCountryByCode")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCountryByCode(string cod)
        {
            try
            {
                var getByCodeCountry = _locationService.GetCountriesByCode(cod.Trim());

                if (getByCodeCountry == null)
                    return NotFound();

                var countriesDto = _mapper.Map<CountriesDto>(getByCodeCountry);
                if(getByCodeCountry.Any())
                    return Ok(countriesDto);

                return NotFound();

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el país. Por favor verificar que el nombre sea el correcto" + ":" +
                    "O que el país se encuentra registrado.", ex);
            }

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
                    var addCountry = _mapper.Map<Countries>(modelDto);

                    addCountry.ProveedoresProveedorId = new Random().Next();
                    //_locationService.Add(addCountry);

                    if (!await _locationService.IsCread(addCountry))
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
        [HttpPut("Id/{Id:int}")]
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


                var getByIdCountry = await _locationService.GetByIdCountriesAsync(Id);

                if (getByIdCountry == null)
                    return BadRequest();

                _mapper.Map(modelDto, getByIdCountry);

                if (await _locationService.IsUpdated(getByIdCountry))
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
                var getById = await _locationService.GetByIdCountriesAsync(Id);
                if (getById == null)
                    return NotFound();

                _locationService.GetByCountriesIsDeleted(getById);
                if (!await _locationService.SaveAll())
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
