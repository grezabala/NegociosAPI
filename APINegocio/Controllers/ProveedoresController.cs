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
        private readonly IRepositoryService _Repo;
        private readonly IMapper Mapper;

        public ProveedoresController(IRepositoryService repositoryService, IMapper mapper)
        {
            _Repo = repositoryService;
            Mapper = mapper;
        }

        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedProveedores = await _Repo.GetProveedoresByIdAsync(id);
            if (deletedProveedores == null)
                return NotFound("ERROR!... EL PROVEEDOR QUE DESEA ELIMINAR NO FUE ENCONTRADO");

            _Repo.Delete(deletedProveedores);
            if (!await _Repo.SaveAll())
                BadRequest("ERROR!... NO SE PUDO ELIMINAR EL PROVEEDOR");

            return Ok(deletedProveedores);
        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getProveedores = await _Repo.GetProveedores();
            return Ok(getProveedores);
        }

        [AllowAnonymous]
        [HttpGet("Id")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int Id)
        {
            var getProveedorById = await _Repo.GetProveedoresByIdAsync(Id);
            if (getProveedorById == null)
                return NotFound("ERROR!... EL PROVEEDOR NO FUE ENCONTRADO");

            return Ok(getProveedorById);
        }

        [AllowAnonymous]
        [HttpGet("name/{name}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string names)
        {
            var getNameProveedor = await _Repo.GetProveedoresByNameAsync(names);
            if (getNameProveedor == null)
                return NotFound("ERROR!... EL PROVEEDOR NO FUE ENCONTRADO");

            return Ok(getNameProveedor);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProveedoresPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(ProveedoresPOSTDto modelDto)
        {
            var addProveedor = Mapper.Map<Proveedores>(modelDto);
            _Repo.Add(addProveedor);

            if (await _Repo.SaveAll())
                return Ok(addProveedor);

            return BadRequest();
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(ProveedoresPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, ProveedoresPUTDto modelDto) 
        {
          if(Id != modelDto.ProveedorId)
                 return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDEN CON NINGUN PROVEEDPOR");

            var updatedProveedor = await _Repo.GetProveedoresByIdAsync(modelDto.ProveedorId);
            if (updatedProveedor == null) return BadRequest();

            Mapper.Map(modelDto, updatedProveedor);

            if (!await _Repo.SaveAll()) return BadRequest();

            return Ok(updatedProveedor);
                
        }
    }
}
