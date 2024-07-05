using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINegocio.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class CityController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public CityController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        // GET: api/<CityController>
        //[AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getCity = await _locationService.GetCitys();
                var _getCityDto = new List<CityDto>();

                foreach (var city in getCity)
                {
                    _getCityDto.Add(_mapper.Map<CityDto>(city));
                }

                return Ok(_getCityDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        // GET api/<CityController>/5
        //[AllowAnonymous]
        [HttpGet("{Id:int}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCityById(int Id)
        {
            try
            {
                var getByIdCity = await _locationService.GetByIdCityAsync(Id);

                var getByIdCityDto = _mapper.Map<CityDto>(getByIdCity);

                if (getByIdCityDto == null)
                    return NotFound("ERROR!... NO SE ENCONTRO NINGUNA CIUDAD CON EL ID SUMINISTRADO, POR FAVOR VERIFICAR QUE EL ID ES CORRECTO");

                return Ok(getByIdCityDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        // GET api/<CityController>/5
        //[AllowAnonymous]
        [HttpGet("~/GetCityByName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCityByName(string name)
        {
            try
            {
                var getByNameCity = await _locationService.GetByNameCityAsync(name.Trim());

                if (getByNameCity == null)
                {
                    return NotFound();

                }

                //var getByNameCityDto = _mapper.Map<CityDto>(getByNameCity);

                if (getByNameCity.Any())
                {
                    return Ok(getByNameCity);
                }

                //if (getByNameCityDto == null)
                //    return NotFound("ERROR!... EL ID DEL LA CIUDAD NO EXISTE");

                return NoContent();


            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        // POST api/<CityController>
        //[Authorize]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CityPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] CityPOSTDto modelDto)
        {

            try
            {
                var addCity = _mapper.Map<City>(modelDto);

                _locationService.Add(addCity);

                if (await _locationService.IsCread(addCity))
                    return Ok(addCity);

                return BadRequest();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salió mal al registrar la nueva Ciudad", ex);
            }

        }

        // PUT api/<CityController>/5
        //[Authorize]
        [HttpPut("{Id}")]
        [ProducesResponseType(201, Type = typeof(CityPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Put(int Id, [FromBody] CityPUTDto modelDto)
        {
            if (Id != modelDto.CityId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUNA CIUDAD");

            var updateCity = await _locationService.GetByIdCityAsync((int)modelDto.CityId);

            if (updateCity == null)
                return BadRequest();

            _mapper.Map(modelDto, updateCity);

            if (await _locationService.IsUpdated(updateCity))
                return NoContent();

            return Ok(updateCity);
        }

        // DELETE api/<CityController>/5
        //[Authorize]
        [HttpDelete("Id/{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Deleted(int Id)
        {
            try
            {
                var deletedCity = await _locationService.GetByIdCityAsync(Id);
                if (deletedCity == null)
                    return NotFound("ERROR!... EL ID DE LA CIUDAD QUE NO FUE ENCONTRADO");

                if (!_locationService.GetByCityIsDeleted(deletedCity))
                {
                    ModelState.AddModelError("", "Error!!! No fue posible eliminar la Ciudad");
                    return StatusCode(500, ModelState);
                }

                return NoContent();

                //_LocationService.GetByCityIsDeleted(deletedCity);
                //if (!await _LocationService.SaveAll())
                //return BadRequest("EROOR!... NO FUE POSIBLE ELIMINAR ESTA CIUDAD");

                //return Ok("ESTA CIUDAD FUE ELIMINADA");
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar la Ciudad", ex);
            }

        }
    }
}
