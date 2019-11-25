using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProductoServices
{
    public class EliminarProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DeleteProductoResponse Ejecutar(string CodigoProducto)
        {
            var producto = _unitOfWork.ProductoRepository.FindFirstOrDefault(t => t.Codigo == CodigoProducto);
            if (producto != null)
            {
                _unitOfWork.ProductoRepository.Delete(producto);
                _unitOfWork.Commit();
                return new DeleteProductoResponse() { Mensaje = "Producto eliminado Correctamente."};
            }
            else
            {
                return new DeleteProductoResponse() { Mensaje = "Error, el producto a eliminar no existe", Error = true };
            }
        }
    }

    public class DeleteProductoResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
