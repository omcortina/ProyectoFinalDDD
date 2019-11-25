using Dominio.Entities;
using Dominio.Repositories;
using Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(IDbContext context)
              : base(context)
        {

        }
    }
}
