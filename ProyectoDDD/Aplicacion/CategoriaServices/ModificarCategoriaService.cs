using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CategoriaServices
{
    public class ModificarCategoriaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ModificarCategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public UpdateCategoriaResponse Ejecutar(UpdateCategoriaRequest request)
        {
            var categoria = _unitOfWork.CategoriaRepository.FindFirstOrDefault(t => t.Codigo == request.CodigoCategoria);
            if (categoria != null)
            {

                categoria = new Categoria();
                categoria.Codigo = request.CodigoCategoria;
                categoria.Nombre = request.NombreCategoria;


                _unitOfWork.CategoriaRepository.Edit(categoria);
                _unitOfWork.Commit();
                return new UpdateCategoriaResponse() { Mensaje = "Categoria modificada correctamente" };
            }
            else
            {
                return new UpdateCategoriaResponse() { Mensaje = "Error, la categoria no existe", Error = true };
            }
        }
    }
    public class UpdateCategoriaRequest
    {
        public string CodigoCategoria { get; set; }
        public string NombreCategoria { get; set; }
    }
    public class UpdateCategoriaResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
