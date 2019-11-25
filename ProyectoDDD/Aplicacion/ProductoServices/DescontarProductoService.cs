using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProductoServices
{
    public class DescontarProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        public DescontarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public DescontarProductoResponse Ejecutar(DescontarProductoRequest request)
        {
            var producto = _unitOfWork.ProductoRepository.FindFirstOrProducto(t => t.Codigo == request.CodigoProducto);
            if (producto != null)
            {
                producto.Descontar(request.CantidadDisponibleProducto);

                _unitOfWork.ProductoRepository.Edit(producto);
                _unitOfWork.Commit();
                return new DescontarProductoResponse() { Mensaje = $"El producto {producto.Nombre} ha sido descontado" };
            }
            else
            {
                return new DescontarProductoResponse() { Mensaje = "El producto a descontar no existe", Error = true };
            }
        }
    }
    public class DescontarProductoRequest
    {
        public string CodigoProducto { get; set; }
        public double CantidadDisponibleProducto { get; set; }
    }

    public class DescontarProductoResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
