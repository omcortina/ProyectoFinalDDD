using Dominio.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioTest
{
    public class TestDominioVenta
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void CalcularTotalVentaCantidadCorrecto()
        {
            Categoria categoria = new Categoria() { 
                Codigo = "C-01",
                Nombre = "Postura"
            };

            TipoDeVenta TipoDeVenta = new TipoDeVenta()
            {
                Nombre = "Venta por cantidad"
            };
            Producto producto = new Producto();
            
            producto.Codigo = "P-01";
            producto.Nombre = "Pollito Pre-Iniciacion";
            producto.PrecioCompra = 1000;
            producto.PrecioVenta = 2000;
            producto.UnidadMedida = "Kg";
            producto.CantidadDisponible = 5;
            producto.Categoria = categoria;
            producto.TiposDeVenta.Add(TipoDeVenta);

            Venta venta = new Venta();
            venta.Codigo = "123";
            venta.Fecha = DateTime.Parse("21-11-2019");
            venta.ProductosVendidos.Add(new ProductosVendidos() { 
                Producto = producto,
                CantidadVendida = 3
            });

            double total = venta.CalcularTotalVentaCantidad();
            Assert.AreEqual(total, 6000);
        }
        [Test]
        public void CalcularTotalVentaDineroCorrecto()
        {
            Categoria categoria = new Categoria()
            {
                Codigo = "C-01",
                Nombre = "Postura"
            };
            TipoDeVenta TipoDeVenta = new TipoDeVenta()
            {
                Nombre = "Venta por dinero"
            };
            Producto producto = new Producto();
            producto.Codigo = "P-01";
            producto.Nombre = "Pollito Pre-Iniciacion";
            producto.PrecioCompra = 1000;
            producto.PrecioVenta = 2000;
            producto.UnidadMedida = "Kg";
            producto.CantidadDisponible = 5;
            producto.Categoria = categoria;
            producto.TiposDeVenta.Add(TipoDeVenta);

            Venta venta = new Venta();
            venta.Codigo = "123";
            venta.Fecha = DateTime.Parse("14-11-2019");
            venta.ProductosVendidos.Add(new ProductosVendidos()
            {
                Producto = producto,
                Dinero = 6000
            });

            double total = venta.CalcularTotalVentaDinero();
            Assert.AreEqual(total, 3);
        }
        [Test]
        public void RealizarVentaCorrecta()
        {
            Categoria categoria = new Categoria()
            {
                Codigo = "C-01",
                Nombre = "Postura"
            };
            TipoDeVenta TipoDeVenta = new TipoDeVenta()
            {
                Nombre = "Venta por dinero"
            };
            Producto producto = new Producto();
            producto.Codigo = "P-01";
            producto.Nombre = "Pollito Pre-Iniciacion";
            producto.PrecioCompra = 1000;
            producto.PrecioVenta = 2000;
            producto.UnidadMedida = "Kg";
            producto.CantidadDisponible = 5;
            producto.Categoria = categoria;
            producto.TiposDeVenta.Add(TipoDeVenta);

            Venta venta = new Venta();
            venta.Codigo = "123";
            venta.Fecha = DateTime.Parse("22-11-2019");
            venta.ProductosVendidos.Add(new ProductosVendidos()
            {
                Producto = producto,
                Dinero = 6000
            });
            string respuesta = venta.RealizarVenta("Venta por dinero");
            Assert.AreEqual(respuesta, "La cantidad a vender es: 3 Kg");
        }
    }
}
