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
                if (branchs == null || !branchs.Any())
                {
                    return NoContent();
                }

                // Verifica si todos los elementos en la lista están eliminados
                bool allDeleted = branchs.All(branch => _branchOfficesService.IsDeleted(branch));
                if (!allDeleted)
                {
                    ModelState.AddModelError("", $"Error! Al eliminar la sucursal");
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

        //[AllowAnonymous]
        //[HttpGet("~/GetByBranchOfficeIsDeleted")]
        //[ResponseCache(CacheProfileName = "Default30Seg")]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult GetByBranchOfficeIsDeleted(/*string _branchIsDeleted*/)
        //{
        //    try
        //    {
        //        var _listIsDeleted = _branchOfficesService.GetByBranchOfficeIsDeleted(/*_branchIsDeleted*/);
        //        var _listIsDeletedDto = new List<BranchOfficesDto>();

        //        foreach (var _IsDeletedBranchas in _listIsDeleted)
        //        {
        //            _listIsDeletedDto.Add(_mapper.Map<BranchOfficesDto>(_IsDeletedBranchas));
        //        }

        //        return Ok(_listIsDeletedDto);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error! No se encontro registro eliminado", ex);
        //    }

        //}

        [AllowAnonymous]
        [HttpGet("{Id:int}"/*, Name = "GetByBranchOfficeId"*/)]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBranchOfficeById(int Id)
        {
            try
            {
                var listId = _branchOfficesService.GetByBranchOfficeId(Id);
                var listDto = new List<BranchOfficesDto>();

                foreach (var branchOffices in listId)
                {
                    listDto.Add(_mapper.Map<BranchOfficesDto>(branchOffices));

                }

                if (listDto == null)
                    return NotFound();

                return Ok(listDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error!", ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("~/GetBranchOfficeByName"/*, Name = "GetByBranchOfficeName"*/)]
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

                //var _getBranche = _mapper.Map<BranchOfficesDto>(list);

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
        [HttpGet("code", Name = "GetByBranchOfficeCode")]
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

                //var listDto = _mapper.Map<BranchOfficesDto>(list);
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

        [HttpPut("{Id:int}")]
        [ProducesResponseType(201, Type = typeof(BranchOfficesPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Put(int Id, [FromBody] BranchOfficesPUTDto modelDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(modelDto == null || Id != modelDto.BranchId)
                    return BadRequest(ModelState);

                //if (Id != modelDto.BranchId)
                //    return BadRequest("Error!");

                var _putBranch = _branchOfficesService.GetByBranchOfficeId(Id);

                //if (_putBranch == null)
                //    return BadRequest();

              var branchOffice =  _mapper.Map<BranchOffices>(modelDto);

                if (!_branchOfficesService.IsUpdated(branchOffice))
                {
                    ModelState.AddModelError("", $"ERROR...!\t Al editar el registro {branchOffice.BranchOfficesName}");
                    return StatusCode(500, ModelState);
                
                }

                return NoContent();

                //return Ok(_putBranch);
            }
            catch (Exception ex)
            {

                throw new Exception("Updated.... Error!", ex);
            }
        }

    /*
     
    {
      "branchId": 1008,
      "branchOfficesName": "Club Gonzales II",
      "description": "Club Deportivo Manuel Gonzales",
      "branchOfficesCode": "CLD-015GM",
      "direccion": "Av. Independencia, C./ Marcia Medina. Edif. #23B",
      "contacts": "829-735-9194",
      "referencia": "Club Deportivo para todas las edades.",
      "webSite": "clubdepoertivo.com",
      "facebookAccount": "clubgonzales",
      "instagramAccount": "clubgonzales",
      "whatsAppNumber": "849-345-7654",
      "phoneNumber": "829-994-4507",
      "otherNumber": "849-848-9512",
      "latitud": 59.98857,
      "longitud": -60.16265,
    }
         
    */

    }
}
