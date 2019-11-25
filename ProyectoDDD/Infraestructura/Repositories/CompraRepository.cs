using Dominio.Entities;
using Dominio.Repositories;
using Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class CompraRepository : GenericRepository<Compra>, ICompraRepository
    {
        public CompraRepository(IDbContext context)
              : base(context)
        {

        }
    }
}
