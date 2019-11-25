using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProveedorServices
{
    public class GuardarProveedorService
    {
        readonly IUnitOfWork _unitOfWork;
        public GuardarProveedorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AddProveedorResponse Ejecutar(AddProveedorRequest request)
        {
            var proveedor = _unitOfWork.ProveedorRepository.FindFirstOrDefault(c => c.Codigo == request.CodigoProveedor);
            if (proveedor == null)
            {
                proveedor = new Proveedor();
                proveedor.Codigo = request.CodigoProveedor;
                proveedor.Nombre = request.NombreProveedor;
                proveedor.Telefono = request.TelefonoProveedor;
                proveedor.Direccion = request.DireccionProveedor;

                _unitOfWork.ProveedorRepository.Add(proveedor);
                _unitOfWork.Commit();
                return new AddProveedorResponse() { Mensaje = "Proveedor guardado correctamente" };
            }
            else
            {
                return new AddProveedorResponse() { Mensaje = "El proveedor ya existe", Error = true };
            }
        }
    }

    public class AddProveedorRequest
    {
        public string CodigoProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string DireccionProveedor { get; set; }
    }

    public class AddProveedorResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
