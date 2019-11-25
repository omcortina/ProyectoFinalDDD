using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.ProductoServices;
using Dominio.Contracts;
using Dominio.Entities;
using Infraestructura;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        readonly ProyectoDDDContext _context;
        readonly IUnitOfWork _unitOfWork;

        public ProductoController(ProyectoDDDContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("GuardarProducto")]
        public ActionResult<AddProductoResponse> AddProducto(AddProductoRequest request)
        {
            try
            {
                GuardarProductoService servicio = new GuardarProductoService(_unitOfWork);
                var response = servicio.Ejecutar(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }
        }

        [HttpPost("AbastecerProducto")]
        public ActionResult<AbastecerProductoResponse> AbastecerProducto(AbastecerProductoRequest request)
        {
            try
            {
                AbastecerProductoService servicio = new AbastecerProductoService(_unitOfWork);
                var response = servicio.Ejecutar(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }
        }

        [HttpGet("ConsultarProducto")]
        public ActionResult<Producto> ConsultarProducto(string codigo)
        {
            try
            {
                ConsultarProductoService service = new ConsultarProductoService(_unitOfWork);
                var response = service.Ejecutar(codigo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }
            
        }

        [HttpGet("ConsultarTiposDeVentaProducto")]
        public ActionResult<List<TipoDeVenta>> ConsultarTiposDeVenta(string codigo)
        {
            try
            {
                ListarTiposDeVentaProductoService service = new ListarTiposDeVentaProductoService(_unitOfWork);
                var lista = service.Ejecutar(codigo);
                return Ok(lista.ToArray());
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }
            
        }

        [HttpPost("DescontarProducto")]
        public ActionResult<DescontarProductoResponse> DescontarProducto(DescontarProductoRequest request)
        {
            try
            {
                DescontarProductoService servicio = new DescontarProductoService(_unitOfWork);
                var response = servicio.Ejecutar(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }
        }
    }
}