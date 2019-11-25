using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.VentaServices;
using Dominio.Contracts;
using Infraestructura;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        readonly ProyectoDDDContext _context;
        readonly IUnitOfWork _unitOfWork;

        public VentaController(ProyectoDDDContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("RealizarVentaPorCantidad")]
        public ActionResult<AddVentaCantidadResponse> RealizarVenta(AddVentaCantidadRequest request)
        {
            try
            {
                RegistrarVentaPorCantidadService service = new RegistrarVentaPorCantidadService(_unitOfWork);
                var response = service.Ejecutar(request);
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