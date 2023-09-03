using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Data.Interfaz;
using APINegocio.Aplications.Entities;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINegocio.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IRepositoryService _RepositoryService;

        private readonly IMapper _Mapper;


        public ProductosController(IRepositoryService repositoryService, IMapper mapper)
        {
            this._Mapper = mapper;
            this._RepositoryService = repositoryService;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteProducto = await _RepositoryService.GetProductosByIdAsync(Id);
            if (deleteProducto == null)
                return NotFound("ERROR!... EL PRODUCTO QUE DESEA ELIMINAR NO FUE ENCONTRADO");

            _RepositoryService.Delete(deleteProducto);
            if (!await _RepositoryService.SaveAll())
                return BadRequest("ERROR!... NO SE PUDO ELIMINAR EL PRODUCTO");

            return Ok("EL PRODUCTO FUE ELIMINADO CORRECTAMENTE");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getProductos = await _RepositoryService.GetProductos();
            return Ok(getProductos);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getById = await _RepositoryService.GetProductosByIdAsync(Id);

            if (getById == null)
                return NotFound("ERROR!... EL PRODUCTO NO FUE ENCONTRADO");

            return Ok(getById);
        }

        [HttpGet("name/{name}")] //Ruta personalizada para evitar la ambiguedad entre metodo
        public async Task<IActionResult> Get(Productos model)
        {
            var getName = await _RepositoryService.GetProveedoresByNameAsync(model.ProductName);
                              
            if (getName == null)
                return NotFound("ERROR!... EL PRODUCTO NO FUE ENCONTRADO");

            return Ok(getName);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductosPOSTDto modelDto)
        {
            #region CODIGO EN CASO DE QUE NO SE VAYA IMPLEMENTAR MAPPER
            //var productoNew = new Productos();

            //productoNew.ProductName = modelDto.ProductName;
            //productoNew.Description = modelDto.Referencia;
            //productoNew.Description = modelDto.Descripcion;
            //productoNew.Price = modelDto.Price;

            //productoNew.CreatedDate = DateTime.Now; //Para pasar la fecha por defecto
            //productoNew.IsAsset = true; //Para indicar que un producto esta activo
            //productoNew.IsDeleted = false; //Para indicar si un producto fue eliminado
            //productoNew.IsApproved = true; //Para indicar si un producto fue aprovado
            #endregion

            var productoNew = _Mapper.Map<Productos>(modelDto);

            _RepositoryService.Add(productoNew);

            if (await _RepositoryService.SaveAll())
                return Ok(productoNew);
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] ProductoPUTDto modelDto)
        {

            if (Id != modelDto.ProductId)
                return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN PRODUCTO");

            var updatedProducto = await _RepositoryService.GetProductosByIdAsync(modelDto.ProductId);

            if (updatedProducto == null)
                return BadRequest();

            _Mapper.Map(modelDto, updatedProducto);

            if (!await _RepositoryService.SaveAll())
                return NoContent();

            return Ok(updatedProducto);


            #region CODIGO EN CASO QUE NO SE VAYA A IMPLEMENTAR MAPPER
            /*
            updatedProducto.Description = modelDto.Description;
            updatedProducto.Price = modelDto.Price;
            updatedProducto.ProductName = modelDto.ProductName;
            updatedProducto.Referencia = modelDto.Referencia;
            updatedProducto.IsDateModified = DateTime.Now; //Se pasara la fecha por defecto de cuando fue modificado
            updatedProducto.IsModified = true; //Indicara si fue modificado.
            ---ESTE CODIGO VA DEBAJO DEL if (updatedProducto == null)
                return BadRequest(); */
            #endregion

        }

    }
}
