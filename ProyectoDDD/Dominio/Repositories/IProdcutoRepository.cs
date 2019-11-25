using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Repositories
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        Producto FindFirstOrProducto(Expression<Func<Producto, bool>> predicate);
        Producto BuscarTiposDeVenta(Expression<Func<Producto, bool>> predicate);
    }
}
