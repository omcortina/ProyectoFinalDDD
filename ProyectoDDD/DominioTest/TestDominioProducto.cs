using Dominio.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace DominioTest
{
    public class TestDominioProducto
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AbastecerProductoCorrecto()
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
            Producto producto = new Producto()
            {
                Codigo = "P-01",
                Nombre = "Pre-Inicio Pollito",
                PrecioCompra = 1000,
                PrecioVenta = 1500,
                UnidadMedida = "Kg",
                CantidadDisponible = 0,
                Categoria = categoria 
            };
            producto.TiposDeVenta.Add(TipoDeVenta);
            producto.AbastecerProducto(5);
            
            Assert.AreEqual(5, producto.CantidadDisponible);
        }

        [Test]
        public void DescontarProductoCorrecto()
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
            Producto producto = new Producto()
            {
                Codigo = "P-01",
                Nombre = "Pre-Inicio Pollito",
                PrecioCompra = 1000,
                PrecioVenta = 1500,
                CantidadDisponible = 2,
                UnidadMedida = "Kg",
                Categoria = categoria
            };
            producto.TiposDeVenta.Add(TipoDeVenta);
            producto.Descontar(1);

            Assert.AreEqual(1, producto.CantidadDisponible);
        }
        
    }
}