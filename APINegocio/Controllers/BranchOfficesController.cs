using APINegocio.API.Controllers;
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
    public class BranchOfficesController : ControllerBase
    {

        protected IBranchOfficesService _branchOfficesService { get; }
        protected IMapper _mapper { get; }
        public BranchOfficesController(IBranchOfficesService branchOfficesService, IMapper mapper)
        {
            this._branchOfficesService = branchOfficesService;
            this._mapper = mapper;
        }


        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Deleted(int branchId)
        {
            try
            {
                if (!_branchOfficesService.IsExisteByBranchOfficesId(branchId))
                {
                    return NoContent();
                }

                var branchs = _branchOfficesService.ListById(branchId);

                if (!_branchOfficesService.IsDeleted(branchs))
                {
                    ModelState.AddModelError("", $"Error! Al eliminar la Marcha");
                    return StatusCode(500, ModelState);
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            try
            {
                var list = _branchOfficesService.List();
                var listDto = new List<BranchOfficesPOSTDto>();

                foreach (var branchList in list)
                {
                    listDto.Add(_mapper.Map<BranchOfficesPOSTDto>(branchList));
                }

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int Id)
        {
            try
            {
                var listId = _branchOfficesService.ListById(Id);
                if (listId == null)
                    return NotFound();

                var listDto = _mapper.Map<BranchOfficesDto>(listId);
                return Ok(listDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error!", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("name")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string nombre)
        {
            try
            {
                var list = _branchOfficesService.ListByName(nombre.Trim());
                if (list == null)
                    return NotFound();

                if (list.Any())
                    return Ok(list);

                return NoContent();

                //var listDto = _mapper.Map<BranchOfficesDto>(list);

            }
            catch (Exception ex)
            {
                throw new Exception("LIST... ERROR!", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("code")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByCode(string codigo)
        {
            try
            {
                var list = _branchOfficesService.ListByCode(codigo.Trim());
                if (list == null)
                    return NotFound();

               // var listDto = _mapper.Map<BranchOfficesDto>(list);
               if(list.Any())
                return Ok(list);

               return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception("LIST... ERROR!", ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BranchOfficesPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Post([FromBody] BranchOfficesPOSTDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (model == null)
                    return BadRequest(ModelState);

                if (_branchOfficesService.IsExisteByBranchOfficesName(model.BranchOfficesName))
                {
                    ModelState.AddModelError("", "Error!");
                    return StatusCode(404, ModelState);
                }

                var postBranchs = _mapper.Map<BranchOffices>(model);

                if (!_branchOfficesService.IsCread(postBranchs))
                    return Ok(postBranchs);

                return BadRequest();
            }
            catch (Exception ex)
            {

                throw new Exception("CREAD.... ERROR!", ex);
            }
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(BranchOfficesPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Put(int Id, [FromBody] BranchOfficesPUTDto model)
        {
            try
            {
                if (Id != model.BranchId)
                    return BadRequest("Error!");

                var updated = _branchOfficesService.ListById(Id);

                if (updated == null)
                    return BadRequest();

                _mapper.Map(model, updated);

                if (!_branchOfficesService.IsSaveAll())
                    return NoContent();

                return Ok(updated);
            }
            catch (Exception ex)
            {

                throw new Exception("Updated.... Error!", ex);
            }
        }
    }
}
