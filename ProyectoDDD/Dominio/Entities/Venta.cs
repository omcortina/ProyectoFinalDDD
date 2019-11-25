using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entities
{
    public class Venta : Entity<int>
    {
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public List<ProductosVendidos> ProductosVendidos { get; set; } = new List<ProductosVendidos>();
        public double Total { get; set; } = 0;
        public string TipoDeVenta { get; set; }
        
        public double CalcularTotalVentaCantidad()
        {
            double total = 0;
            
            foreach (ProductosVendidos productoVendidoCantidad in ProductosVendidos)
            {
                var producto = productoVendidoCantidad.Producto;
                foreach (TipoDeVenta tipoVenta in producto.TiposDeVenta)
                {
                    if (tipoVenta.Nombre == "Venta por cantidad")
                    {
                        producto.Descontar(productoVendidoCantidad.CantidadVendida);
                        total += producto.PrecioVenta * productoVendidoCantidad.CantidadVendida;
                        return total;
                    }
                }   
            }
            return total;
        }
        
        public double CalcularTotalVentaDinero()
        {
            double total = 0;
            foreach (ProductosVendidos productoVendidoDinero in ProductosVendidos)
            {
                var producto = productoVendidoDinero.Producto;
                foreach (TipoDeVenta tipoVenta in producto.TiposDeVenta)
                {
                    if (tipoVenta.Nombre == "Venta por dinero")
                    {
                        var cantidad = productoVendidoDinero.Dinero / producto.PrecioVenta;
                        producto.Descontar(cantidad);
                        total += cantidad;
                        return total;
                    }
                }     
            }
            return total;
        }

        public string RealizarVenta(string tipoDeVenta)
        {
            
            if (tipoDeVenta == "Venta por cantidad")
            {
                Total = CalcularTotalVentaCantidad();
                return $"El total a pagar es de: {Total} pesos";
            }
            else if(tipoDeVenta == "Venta por dinero")
            {
                Total = CalcularTotalVentaDinero();
                return $"La cantidad a vender es: {Total} Kg";
            }
            else
            {
                return "Tipo de venta invalido";
            }
        }
    }

    public class ProductosVendidos : Entity<int>
    {
        public Producto Producto { get; set; } = new Producto();
        public double CantidadVendida { get; set; }
        public double Dinero { get; set; }
        
    }
}
