using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProductoServices
{
    public class ConsultarProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ConsultarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Producto Ejecutar(string codigo)
        {
            var producto = _unitOfWork.ProductoRepository.FindFirstOrProducto(c=>c.Codigo == codigo);
            return producto;
        }
    }
}
