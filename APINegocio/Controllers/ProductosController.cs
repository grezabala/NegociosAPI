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
        private readonly IRepositoryService _repositoryService;

        private readonly IMapper _mapper;

        public ProductosController(IRepositoryService repositoryService, IMapper mapper)
        {
            this._repositoryService = repositoryService;
            this._mapper = mapper;

        }

        [HttpDelete("Id/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var deleteProducto = await _repositoryService.GetProductosByIdAsync(Id);
                if (deleteProducto == null)
                    return NotFound("ERROR!... EL PRODUCTO QUE DESEA ELIMINAR NO FUE ENCONTRADO");

                if (!_repositoryService.GetProductosByDeleted(deleteProducto))
                {
                    return Ok("EL PRODUCTO FUE ELIMINADO CORRECTAMENTE");
                }
                return BadRequest("ERROR!... NO SE PUDO ELIMINAR EL PRODUCTO");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al eliminar el producto, por favor verificar que el producto exista.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var _getProductos = await _repositoryService.GetProductos();
                var _getProductosDto = new List<ProductosDto>();

                foreach (var productos in _getProductos)
                {
                    _getProductosDto.Add(_mapper.Map<ProductosDto>(productos));
                }

                return Ok(_getProductosDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar todos los productos, por favor vuelva a intentarlo.", ex);
            }

            //var getProductos = await _repositoryService.GetProductos();
            //return Ok(getProductos);
        }

        [AllowAnonymous]
        [HttpGet("{Id:int}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductoById(int Id)
        {
            try
            {
                var getById = await _repositoryService.GetProductosByIdAsync(Id);

                var _getByIdDto = _mapper.Map<ProductosDto>(getById);

                if (_getByIdDto == null)
                    return NotFound("ERROR!... EL PRODUCTO NO FUE ENCONTRADO");

                return Ok(_getByIdDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el producto, por favor validar que el ID sea el correcto.", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{name}")] //Ruta personalizada para evitar la ambiguedad entre metodo
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductoByName(string nombre)
        {
            try
            {
                var getName = await _repositoryService.GetProductosByNameAsync(nombre);

                var _getNameDto = _mapper.Map<ProductosDto>(getName);

                if (_getNameDto == null)
                    return NotFound("ERROR!... EL PRODUCTO NO FUE ENCONTRADO");

                return Ok(_getNameDto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el producto, por favor validar que el nombre sea el correcto.", ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProductosPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(ProductosPOSTDto modelDto)
        {
            //REALIZAR UN METODO GET PARA FILTRAR POR CODIGO
            try
            {
                var productoNew = _mapper.Map<Productos>(modelDto);

                productoNew.IsAsset = true;
                productoNew.IsDeleted = false;
                productoNew.CreatedDate = DateTime.Now;
                productoNew.IsApproved = true;
                productoNew.IsApprovedAt = DateTime.Now;
                productoNew.IsDeletedAt = null;
                productoNew.IsDateModified = null;

                _repositoryService.Add(productoNew);

                if (await _repositoryService.SaveAll())
                    return Ok(productoNew);

                return BadRequest();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible registrar el nuevo producto. Por favor vuelva a intentarlo.", ex);
            }

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
        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(ProductoPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(int Id, [FromBody] ProductoPUTDto modelDto)
        {
            try
            {
                if (Id != modelDto.ProductId)
                    return BadRequest("ERROR!... EL ID QUE ACABA DE INGRESAR NO COINCIDE CON NINGUN PRODUCTO");

                var updatedProducto = await _repositoryService.GetProductosByIdAsync(modelDto.ProductId);

                if (updatedProducto == null)
                    return BadRequest();

                _mapper.Map(modelDto, updatedProducto);

                if (!await _repositoryService.SaveAll())
                    return NoContent();

                return Ok(updatedProducto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible editar el producto. Por favor vuelva a intentarlo.", ex);
            }

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
