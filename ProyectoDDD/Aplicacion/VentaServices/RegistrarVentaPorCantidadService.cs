using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.VentaServices
{
    public class RegistrarVentaPorCantidadService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarVentaPorCantidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AddVentaCantidadResponse Ejecutar(AddVentaCantidadRequest request)
        {
            var venta = _unitOfWork.VentaRepository.FindFirstOrDefault(t => t.Codigo == request.CodigoVenta);
            if (venta == null)
            {
                
                venta = new Venta();   
                venta.Codigo = request.CodigoVenta;
                venta.Fecha = DateTime.Parse(request.FechaVenta);
                
                foreach (ProductosVendidos _producto in request.ProductosVendidosPorCantidad)
                {
                    var producto = _unitOfWork.ProductoRepository.FindFirstOrProducto(p => p.Codigo == request.CodigoProducto);
                    venta.ProductosVendidos.Add(new ProductosVendidos()
                    {
                        Producto = producto,
                        CantidadVendida = _producto.CantidadVendida
                    }) ;
                }
                venta.RealizarVenta(request.TipoDeVentaProducto);
                venta.TipoDeVenta = request.TipoDeVentaProducto;

                _unitOfWork.VentaRepository.Add(venta);
                _unitOfWork.Commit();
                return new AddVentaCantidadResponse() { Mensaje = "Venta registrada correctamente" };
            }
            else
            {
                return new AddVentaCantidadResponse() { Mensaje = "Error, la venta ya existe", Error = true };
            }
        }
    }

    public class AddVentaCantidadRequest
    {
        public string CodigoVenta { get; set; }
        public string FechaVenta { get; set; }
        public string CodigoProducto { get; set; }
        public List<ProductosVendidos> ProductosVendidosPorCantidad { get; set; } = new List<ProductosVendidos>();
        public string TipoDeVentaProducto { get; set; }
    }
    public class AddVentaCantidadResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
