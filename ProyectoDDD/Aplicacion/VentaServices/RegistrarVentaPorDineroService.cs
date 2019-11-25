using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.VentaServices
{
    public class RegistrarVentaPorDineroService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarVentaPorDineroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
