using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entities
{
    public class Producto : Entity<int>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public string UnidadMedida { get; set; }
        public double CantidadDisponible { get; set; } = 0;
        public Categoria Categoria { get; set; } = new Categoria();
        public List<TipoDeVenta> TiposDeVenta { get; set; } = new List<TipoDeVenta>();

        public void AbastecerProducto(double cantidad)
        {
            this.CantidadDisponible += cantidad;
            
        }

        public void Descontar(double cantidad)
        {
                this.CantidadDisponible -= cantidad;
        }
    }

    public class TipoDeVenta : Entity<int>
    {
        public string Nombre { get; set; }
    }
}
