using Dominio.Entities;
using Dominio.Repositories;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infraestructura.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(IDbContext context)
              : base(context)
        {

        }

        public Producto BuscarTiposDeVenta(Expression<Func<Producto, bool>> predicate)
        {
            var producto = _dbset.Where(predicate).Include(p => p.TiposDeVenta).ToList().FirstOrDefault();
            return producto;
        }

        public Producto FindFirstOrProducto(Expression<Func<Producto, bool>> predicate)
        {
            Producto producto = _dbset.Include(c=>c.Categoria).Include(t=>t.TiposDeVenta).FirstOrDefault();
            return producto;
        } 
    }
}
