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
    //[Authorize]
    public class BranchOfficesController : ControllerBase
    {
        protected IBranchOfficesService _branchOfficesService { get; }
        protected IMapper _mapper { get; }
        public BranchOfficesController(IBranchOfficesService branchOfficesService, IMapper mapper)
        {
            this._branchOfficesService = branchOfficesService;
            this._mapper = mapper;
        }

        [HttpDelete("Id/{Id:int}")]
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

                var branchs = _branchOfficesService.GetByBranchOfficeId(branchId);

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
        [HttpGet(Name = "GetBranchOffice")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBranchOffice()
        {
            try
            {
                var list = _branchOfficesService.GetBranchOffices();
                var listDto = new List<BranchOfficesDto>();

                foreach (var branchList in list)
                {
                    listDto.Add(_mapper.Map<BranchOfficesDto>(branchList));
                }

                return Ok(listDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("~/GetByBranchOfficeIsDeleted")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByBranchOfficeIsDeleted(/*string _branchIsDeleted*/)
        {
            try
            {
                var _listIsDeleted = _branchOfficesService.GetByBranchOfficeIsDeleted(/*_branchIsDeleted*/);
                var _listIsDeletedDto = new List<BranchOfficesDto>();

                foreach (var _IsDeletedBranchas in _listIsDeleted)
                {
                    _listIsDeletedDto.Add(_mapper.Map<BranchOfficesDto>(_IsDeletedBranchas));
                }

                return Ok(_listIsDeletedDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No se encontro registro eliminado", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{Id:int}", Name = "GetByBranchOfficeId")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByBranchOfficeId(int Id)
        {
            try
            {
                var listId = _branchOfficesService.GetByBranchOfficeId(Id);
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
        [HttpGet("{name}", Name = "GetByBranchOfficeName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBranchOfficeByName(string nombre)
        {
            try
            {
                var list = _branchOfficesService.GetBranchOfficeByName(nombre.Trim());
                if (list == null)
                    return NotFound();

                var _getBranche = _mapper.Map<BranchOfficesDto>(list);

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
        [HttpGet("{code}", Name = "GetByBranchOfficeCode")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByBranchOfficeCode(string codigo)
        {
            try
            {
                var list = _branchOfficesService.GetByBranchOfficeCode(codigo.Trim());
                if (list == null)
                    return NotFound();

                // var listDto = _mapper.Map<BranchOfficesDto>(list);
                if (list.Any())
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
                {
                    return BadRequest(ModelState);
                }

                if (model == null)
                {
                    return BadRequest(ModelState);
                }

                if (_branchOfficesService.IsExisteByBranchOfficesName(model.BranchOfficesName))
                {
                    ModelState.AddModelError("", "Error!");
                    return StatusCode(404, ModelState);
                }

                var postBranchs = _mapper.Map<BranchOffices>(model);

                if (!_branchOfficesService.IsCread(postBranchs))
                {
                    return Ok(postBranchs);
                }

                return Ok(postBranchs);
            }
            catch (Exception ex)
            {

                throw new Exception("CREAD.... ERROR!", ex);
            }
        }

        [HttpPut("Id/{Id:int}")]
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

                var updated = _branchOfficesService.GetByBranchOfficeId(Id);

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
