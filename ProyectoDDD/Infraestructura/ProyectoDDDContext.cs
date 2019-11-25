using Dominio.Entities;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura
{
    public class ProyectoDDDContext : DbContextBase
    {
        public ProyectoDDDContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}
