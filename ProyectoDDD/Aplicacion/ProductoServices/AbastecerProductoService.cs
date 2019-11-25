using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProductoServices
{
    public class AbastecerProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        public AbastecerProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AbastecerProductoResponse Ejecutar(AbastecerProductoRequest request)
        {
            var producto = _unitOfWork.ProductoRepository.FindFirstOrProducto(t => t.Codigo == request.CodigoProducto);
            if (producto != null)
            {
                producto.AbastecerProducto(request.CantidadDisponibleProducto);

                _unitOfWork.ProductoRepository.Edit(producto);
                _unitOfWork.Commit();
                return new AbastecerProductoResponse() { Mensaje = $"El producto {producto.Nombre} ha sido abastecido"};
            }
            else
            {
                return new AbastecerProductoResponse() { Mensaje = $"El producto a abastecer no existe", Error = true } ;
            }
        }
    }

    public class AbastecerProductoRequest
    {
        public string CodigoProducto { get; set; }
        public double CantidadDisponibleProducto { get; set; }
    }

    public class AbastecerProductoResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
