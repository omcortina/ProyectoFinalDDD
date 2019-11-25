using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Proveedor : Entity<int>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        //public string Email { get; set; }
    }
}
