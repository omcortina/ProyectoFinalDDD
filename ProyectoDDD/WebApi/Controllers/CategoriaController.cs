using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.CategoriaServices;
using Dominio.Contracts;
using Infraestructura;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        readonly ProyectoDDDContext _context;
        readonly IUnitOfWork _unitOfWork;
        public CategoriaController(ProyectoDDDContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("GuardarCategoria")]
        public ActionResult<AddCategoriaResponse> AddProducto(AddCategoriaRequest request)
        {
            try
            {
                GuardarCategoriaService servicio = new GuardarCategoriaService(_unitOfWork);
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