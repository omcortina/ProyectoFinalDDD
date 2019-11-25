using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProductoServices
{
    public class ModificarProductoService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public UpdateProductoResponse Ejecutar(UpdateProductoRequest request)
        {
            var categoria = _unitOfWork.CategoriaRepository.FindFirstOrDefault(c => c.Codigo == request.CodigoCategoria);
            if (categoria != null)
            {
                var producto = _unitOfWork.ProductoRepository.FindFirstOrProducto(t => t.Codigo == request.CodigoProducto);
                if (producto != null)
                {
                    producto = new Producto();
                    producto.Codigo = request.CodigoProducto;
                    producto.Nombre = request.NombreProducto;
                    producto.PrecioCompra = request.PrecioCompraProducto;
                    producto.PrecioVenta = request.PrecioVentaProducto;
                    producto.UnidadMedida = request.UnidadMedidaProducto;
                    producto.Categoria.Codigo = request.CodigoCategoria;
                    producto.TiposDeVenta = new List<TipoDeVenta>();

                    foreach (TipoDeVenta tipoVenta in request.TiposDeVentaProducto)
                    {
                        producto.TiposDeVenta.Add(tipoVenta);
                    }

                    _unitOfWork.ProductoRepository.Edit(producto);
                    _unitOfWork.Commit();
                    return new UpdateProductoResponse() { Mensaje = "Producto modificado correctamente" };
                }
                else
                {
                    return new UpdateProductoResponse() { Mensaje = "Error, el producto no existe", Error = true };
                }
            }
            else
            {
                return new UpdateProductoResponse() { Mensaje = "Error, la categoria no existe", Error = true };
            }
            
        }
    }

    public class UpdateProductoRequest
    {
        public string CodigoProducto { get; set; }
        public string CodigoCategoria { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioCompraProducto { get; set; }
        public double PrecioVentaProducto { get; set; }
        public string UnidadMedidaProducto { get; set; }
        public List<TipoDeVenta> TiposDeVentaProducto { get; set; } = new List<TipoDeVenta>();

    }
    public class UpdateProductoResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
