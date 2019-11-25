using Dominio.Contracts;
using Dominio.Repositories;
using Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private IProductoRepository _productoRepository;
        public IProductoRepository ProductoRepository { get { return _productoRepository ?? (_productoRepository = new ProductoRepository(_dbContext)); } }

        private ICategoriaRepository _categoriaRepository;  
        public ICategoriaRepository CategoriaRepository { get { return _categoriaRepository ?? (_categoriaRepository = new CategoriaRepository(_dbContext)); } }
        
        private IVentaRepository _ventaRepository;
        public IVentaRepository VentaRepository { get { return _ventaRepository ?? (_ventaRepository = new VentaRepository(_dbContext)); } }
        
        private IProveedorRepository _proveedorRepository;
        public IProveedorRepository ProveedorRepository { get { return _proveedorRepository ?? (_proveedorRepository = new ProveedorRepository(_dbContext)); } }

        private ICompraRepository _compraRepository;
        public ICompraRepository CompraRepository { get { return _compraRepository ?? (_compraRepository = new CompraRepository(_dbContext)); } }
        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
