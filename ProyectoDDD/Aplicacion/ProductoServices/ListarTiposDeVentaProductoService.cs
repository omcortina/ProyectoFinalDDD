using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProductoServices
{
    public class ListarTiposDeVentaProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ListarTiposDeVentaProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TipoDeVenta> Ejecutar(string codigo)
        {
             var producto = _unitOfWork.ProductoRepository.BuscarTiposDeVenta(p => p.Codigo == codigo);
            return producto.TiposDeVenta;
        }
    }
}
