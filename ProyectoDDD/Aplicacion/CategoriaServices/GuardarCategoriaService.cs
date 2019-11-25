using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CategoriaServices
{
    public class GuardarCategoriaService
    {
        readonly IUnitOfWork _unitOfWork;

        public GuardarCategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AddCategoriaResponse Ejecutar(AddCategoriaRequest request)
        {
            var categoria = _unitOfWork.CategoriaRepository.FindFirstOrDefault(t => t.Codigo == request.CodigoCategoria);
            if (categoria == null)
            {

                    categoria = new Categoria();
                    categoria.Codigo = request.CodigoCategoria;
                    categoria.Nombre = request.NombreCategoria;
                    

                    _unitOfWork.CategoriaRepository.Add(categoria);
                    _unitOfWork.Commit();
                    return new AddCategoriaResponse() { Mensaje = "Categoria guardada correctamente" };
            }
            else
            {
                return new AddCategoriaResponse() { Mensaje = "Error, la categoria ya existe", Error = true };
            }
        }
    }
    public class AddCategoriaRequest
    {
        public string CodigoCategoria { get; set; }        
        public string NombreCategoria { get; set; }
    }
    public class AddCategoriaResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
