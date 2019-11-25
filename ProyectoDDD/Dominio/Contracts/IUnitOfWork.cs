using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductoRepository ProductoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IVentaRepository VentaRepository { get; }
        IProveedorRepository ProveedorRepository { get; }
        ICompraRepository CompraRepository { get; }
        int Commit();
    }
}
