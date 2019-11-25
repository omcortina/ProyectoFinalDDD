using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Compra : Entity<int>
    {
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public Producto Producto { get; set; } = new Producto();
        public Proveedor Proveedor { get; set; } = new Proveedor();
        public double CantidadProducto { get; set; } = 0; 
        public double Valor { get; set; }

        public void RealizarCompra(Producto producto, Proveedor proveedor, double valor, double cantidad)
        {
            this.Producto = producto;
            this.Proveedor = proveedor;
            this.Valor = valor;
            this.CantidadProducto = cantidad;
            producto.AbastecerProducto(cantidad);
        }
    }
}
