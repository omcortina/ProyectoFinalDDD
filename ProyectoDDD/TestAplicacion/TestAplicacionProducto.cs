using Aplicacion.ProductoServices;
using Dominio.Entities;
using Infraestructura;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace TestAplicacion
{
    public class TestAplicacionProducto
    {
        ProyectoDDDContext _context;
        UnitOfWork _unitOfWorkMemory;
        UnitOfWork _unitOfWorkDB;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ProyectoDDDContext>().UseInMemoryDatabase("ProyectoDDD").Options;
            var optionsSql = new DbContextOptionsBuilder<ProyectoDDDContext>().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProyectoDDD;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            
            _context = new ProyectoDDDContext(optionsInMemory);
            _unitOfWorkMemory = new UnitOfWork(_context);

            _context = new ProyectoDDDContext(optionsSql);
            _unitOfWorkDB = new UnitOfWork(_context);
        }

        [Test]
        public void GuardarProductoServiceCorrecto()
        {
            Categoria categoria = new Categoria()
            {
                Codigo = "C-01",
                Nombre = "Postura"
            };
            TipoDeVenta tipoVenta1 = new TipoDeVenta() 
            {
                Nombre = "Venta por dinero"
            };
            TipoDeVenta tipoVenta2 = new TipoDeVenta()
            {
                Nombre = "Venta por cantidad"
            };

            AddProductoRequest request = new AddProductoRequest();
            request.CodigoProducto = "P-01";
            request.NombreProducto = "Pollito Pre-Iniciacion";
            request.PrecioCompraProducto = 1000;
            request.PrecioVentaProducto = 2000;
            request.UnidadMedidaProducto = "Kg";
            request.TiposDeVentaProducto.Add(tipoVenta1);
            request.TiposDeVentaProducto.Add(tipoVenta2);
            request.CodigoCategoria = categoria.Codigo;
            
            GuardarProductoService _service = new GuardarProductoService(_unitOfWorkMemory);
            var response = _service.Ejecutar(request);
            Assert.AreEqual(response.Error, false);
        }
        [Test]
        public void ModificarProductoServiceCorrecto()
        {
            ModificarProductoService _service = new ModificarProductoService(_unitOfWorkMemory);
            Categoria categoria = new Categoria()
            {
                Codigo = "C-02",
                Nombre = "Levante"
            };
            TipoDeVenta tipoVenta1 = new TipoDeVenta()
            {
                Nombre = "Venta por dinero"
            };            

            Producto producto = new Producto() {
                Codigo = "S-01",
                Nombre = "Super Pollito",
                PrecioCompra = 1500,
                PrecioVenta = 2500,
                UnidadMedida = "Kg",
                CantidadDisponible = 3,
                Categoria = categoria
            };
            producto.TiposDeVenta.Add(tipoVenta1);

            TipoDeVenta tipoVenta2 = new TipoDeVenta()
            {
                Nombre = "Venta por cantidad"
            };

            Categoria categoria2 = new Categoria()
            {
                Codigo = "C-03",
                Nombre = "Engorde"
            };

            UpdateProductoRequest request = new UpdateProductoRequest();
            request.CodigoProducto = "S-01";
            request.NombreProducto = "Super Pollito Engorde";
            request.PrecioCompraProducto = 1700;
            request.PrecioVentaProducto = 2700;
            request.UnidadMedidaProducto = "kg";
            request.CodigoCategoria = categoria2.Codigo;
            request.TiposDeVentaProducto.Add(tipoVenta2);


            var response = _service.Ejecutar(request);
            Assert.AreEqual(response.Error, false);
        }
    }
}