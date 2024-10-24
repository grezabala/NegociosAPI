using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Data.Interfaz;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APINegocio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedoresController : ControllerBase
    {
        private readonly IRepositoryService _repo;
        private readonly IMapper _mapper;

        public ProveedoresController(IRepositoryService repositoryService, IMapper mapper)
        {
            _repo = repositoryService;
            _mapper = mapper;
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var deletedProveedores = await _repo.GetProveedoresByIdAsync(Id);

                if (!_repo.GetProveedorByIsDeleted(deletedProveedores))
                {
                    ModelState.AddModelError("", $"Algo salió mal al eliminar el proveedor... {deletedProveedores}");
                    return StatusCode(500, ModelState);
                }

                return Ok(deletedProveedores);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! ", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProveedores()
        {
            try
            {
                var _getProveedores = await _repo.GetProveedores();
                var _getProveedoresDto = new List<ProveedoresDto>();

                foreach (var proveee in _getProveedores)
                {
                    _getProveedoresDto.Add(_mapper.Map<ProveedoresDto>(proveee));
                }

                return Ok(_getProveedoresDto);

                //var getProveedores = await _repo.GetProveedores();
                //           return Ok(getProveedores);
            }
            catch (Exception ex)
            {

                throw new Exception("Error....!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{Id:int}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProveedorById(int Id)
        {
            try
            {
                var getProveedorById = await _repo.GetProveedoresByIdAsync(Id);

                var _getProveedorByIdDto = _mapper.Map<ProveedoresDto>(getProveedorById);

                if (_getProveedorByIdDto == null)
                    return NotFound("ERROR!... EL PROVEEDOR NO FUE ENCONTRADO");

                return Ok(_getProveedorByIdDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetProveedorByName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProveedorByName(string names)
        {
            try
            {
                var getNameProveedor = await _repo.GetProveedoresByNameAsync(names);

                var _getNameProveedorDto = new List<ProveedoresDto>();

                foreach (var proveedores in getNameProveedor)
                {
                    _getNameProveedorDto.Add(_mapper.Map<ProveedoresDto>(proveedores));

                }

                if (_getNameProveedorDto == null)
                    return NotFound("ERROR!... EL PROVEEDOR NO FUE ENCONTRADO");

                return Ok(_getNameProveedorDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error....!", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetProveedorByCode")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProveedorByCode(string code)
        {
            try
            {
                var getCode = await _repo.GetByProveedorCodeAsync(code);

                var _getCodeDto = new List<ProveedoresDto>();

                foreach (var proveedores in getCode)
                {

                    _getCodeDto.Add(_mapper.Map<ProveedoresDto>(proveedores));

                }

                if (_getCodeDto == null)
                    return NotFound("ERROR!... EL PROVEEDOR NO FUE ENCONTRADO");

                return Ok(_getCodeDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProveedoresPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(ProveedoresPOSTDto modelDto)
        {
            try
            {
                var addProveedor = _mapper.Map<Proveedores>(modelDto);

                addProveedor.IsDeleted = false;
                addProveedor.IsDeletedAt = null;
                addProveedor.IsModified = false;
                addProveedor.IsDateModified = null;
                addProveedor.CreadProveedor = DateTime.Now;
                addProveedor.IsAsset = true;

                _repo.Add(addProveedor);

                if (await _repo.SaveAll())
                    return Ok(addProveedor);

                return BadRequest();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al agregar el nuevo proveedor.", ex);
            }

        }

        [HttpPut("{Id:int}")]
        [ProducesResponseType(201, Type = typeof(ProveedoresPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, ProveedoresPUTDto modelDto)
        {
            try
            {
                if (Id != modelDto.ProveedorId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN PROVEEDPOR");

                var updatedProveedor = await _repo.GetProveedoresByIdAsync(modelDto.ProveedorId);
                if (updatedProveedor == null) return BadRequest();

                _mapper.Map(modelDto, updatedProveedor);

                updatedProveedor.IsDeleted = false;
                updatedProveedor.IsDeletedAt = null;
                updatedProveedor.IsModified = true;
                updatedProveedor.IsDateModified = DateTime.Now;
                updatedProveedor.CreadProveedor = null;
                updatedProveedor.IsAsset = true;

                if (!await _repo.SaveAll()) return BadRequest();

                return Ok(updatedProveedor);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al editar el registro.", ex);
            }


        }
    }
}
