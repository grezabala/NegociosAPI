﻿using APINegocio.Aplications.Data.Services.Interfaz;
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
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ILogisticaService _logiticaServices;
        private readonly IMapper _mapper;

        public CustomersController(ILogisticaService logiticaServices, IMapper mapper)
        {
            _logiticaServices = logiticaServices;
            _mapper = mapper;
        }

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
                var deletedCustomer = await _logiticaServices.GetCustomersByIdAsync(Id);
                if (deletedCustomer is null)
                    return NotFound("ERROR!... EL ID DEL CLIENTE NO FUE ENCONTRADO");

                if (_logiticaServices.GetByCustomerIsDeleted(deletedCustomer))
                {
                    ModelState.AddModelError("", "Error! No fue posible eliminar el registro");
                    StatusCode(500, ModelState);

                }

                return NoContent();

                //if (!await _logiticaServices.SaveAll())
                //    return BadRequest("ERROR!... NO FUE POSIBLE ELIMINAR EL CLIENTE");
                //return Ok("EL CLIENTE FUE ELIMINADO CORRECTAMENTE");
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salió mal al eliminar el Cliente", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var getCustomer = await _logiticaServices.GetCliente();
                if (getCustomer == null)
                    return NotFound();
                return Ok(getCustomer);
            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salió mal al mostrar todos los clientes", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{Id:int}")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCustomerId(int Id)
        {
            try
            {
                var getCustomerById = await _logiticaServices.GetCustomersByIdAsync(Id);
                if (getCustomerById is null)
                    return NotFound("ERROR! EL CLIENTE NO FUE ENCONTRADO");

                return Ok(getCustomerById);
            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salió mal al mostrar el clientes solicitado, por favor verificar que el ID es correcto", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetByCustomerName")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCustomerName(string nombre)
        {
            try
            {
                var getCustomerName = await _logiticaServices.GetCustomersByNameAsync(nombre);
                if (getCustomerName == null)
                    return NotFound("ERROR!... EL NOMBRE DEL FUE CLIENTE ENCONTRADO");

                return Ok(getCustomerName);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salió mal al mostrar el cliente solicitado, por favor verificar que el nombre esta correcto", ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("~/GetByCustomerCodePostal")]
        [ResponseCache(CacheProfileName = "Default30Seg")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCustomerCodePostal(string codePostal)
        {
            try
            {
                var _getCustomerCodePostal = await _logiticaServices.GetByCustomersByCodeAsync(codePostal);
                if (_getCustomerCodePostal == null)
                    return NotFound("ERROR!... EL NOMBRE DEL FUE CLIENTE ENCONTRADO");

                return Ok(_getCustomerCodePostal);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No fue posible mostrar los clientes", ex);
            }

        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CustomerPOSTDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> POST(CustomerPOSTDto modelDto)
        {
            try
            {
                if (modelDto != null)
                {
                    var postCustomer = _mapper.Map<Customers>(modelDto);
                    postCustomer.IsDeleted = false;
                    postCustomer.IsDeletedAt = null;
                    postCustomer.IsModified = false;
                    postCustomer.IsUpdatedDate = null;
                    postCustomer.CreatedDate = DateTime.Now;
                    postCustomer.IsStatu = true;

                    _logiticaServices.Add(postCustomer);

                    if (await _logiticaServices.SaveAll())
                        return Ok(postCustomer);
                }

                return BadRequest("Error!!! El registro no puedes ser enviardo vacio");
            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salió mal al agregar el nuevo cliente", ex);
            }

        }

        [HttpPut("Id/{Id}")]
        [ProducesResponseType(201, Type = typeof(BranchOfficesPUTDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PUT(int Id, CustomerPUTDto modelDto)
        {

            try
            {
                if (Id != modelDto.CustomerId)
                    return BadRequest("ERROR!... EL ID QUE HAZ INGRESADO NO EXISTE");

                var putCustomer = await _logiticaServices.GetCustomersByIdAsync(modelDto.CustomerId!);
                if (putCustomer is null)
                    return BadRequest();

                modelDto.IsDeleted = false;
                modelDto.IsUpdatedDate = DateTime.Now;
                modelDto.IsModified = true;
                modelDto.IsDeletedAt = null;
                modelDto.IsStatu = true;
                modelDto.CreatedDate = null;

                _mapper.Map(modelDto, putCustomer);

                if (!await _logiticaServices.SaveAll())
                    return BadRequest("EL CLIENTE HAZ SIDO MODIFICADO CORRECTAMENTE");

                return Ok(putCustomer);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No fue posible editar el registro, por favor verificar el ID o si envio un dato vacio", ex);
            }

        }
    }
}
