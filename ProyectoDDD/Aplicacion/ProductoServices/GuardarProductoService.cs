using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.ProductoServices
{
    public class GuardarProductoService
    {
        readonly IUnitOfWork _unitOfWork;

        public GuardarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AddProductoResponse Ejecutar(AddProductoRequest request)
        {
            var categoria = _unitOfWork.CategoriaRepository.FindFirstOrDefault(c => c.Codigo == request.CodigoCategoria);
            if (categoria != null)
            {
                var producto = _unitOfWork.ProductoRepository.FindFirstOrDefault(t => t.Codigo == request.CodigoProducto);
                if (producto == null)
                {

                    producto = new Producto();
                    producto.Codigo = request.CodigoProducto;
                    producto.Nombre = request.NombreProducto;
                    producto.PrecioCompra = request.PrecioCompraProducto;
                    producto.PrecioVenta = request.PrecioVentaProducto;
                    producto.UnidadMedida = request.UnidadMedidaProducto;
                    producto.Categoria = categoria;
                    producto.TiposDeVenta = new List<TipoDeVenta>();

                    foreach (TipoDeVenta tipoVenta in request.TiposDeVentaProducto)
                    {
                        producto.TiposDeVenta.Add(tipoVenta);
                    }

                    _unitOfWork.ProductoRepository.Add(producto);
                    _unitOfWork.Commit();
                    return new AddProductoResponse() { Mensaje = "Producto guardado correctamente" };
                }
                else
                {
                    return new AddProductoResponse() { Mensaje = "Error, el producto ya existe", Error = true };
                }
                
            }
            else
            {
                return new AddProductoResponse() { Mensaje = "Error, la categoria no existe", Error = true };
            }
        }
    }

    public class AddProductoRequest
    {
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioCompraProducto { get; set; }
        public double PrecioVentaProducto { get; set; }
        public string UnidadMedidaProducto { get; set; }
        public string CodigoCategoria { get; set; }
        public List<TipoDeVenta> TiposDeVentaProducto { get; set; } = new List<TipoDeVenta>();
        
    }
    public class AddProductoResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
