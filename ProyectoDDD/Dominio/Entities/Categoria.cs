using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Categoria : Entity<int>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public Categoria(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public Categoria()
        {
        }
    }
}
