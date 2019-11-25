using Dominio.Contracts;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.ProveedorServices
{
    public class ModificarProveedorService
    {
        readonly IUnitOfWork _unitOfWork;
        public ModificarProveedorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public UpdateProveedorResponse Ejecutar(UpdateProveedorRequest request)
        {
            var proveedor = _unitOfWork.ProveedorRepository.FindFirstOrDefault(c => c.Codigo == request.CodigoProveedor);
            if (proveedor != null)
            {
                proveedor = new Proveedor();
                proveedor.Codigo = request.CodigoProveedor;
                proveedor.Nombre = request.NombreProveedor;
                proveedor.Telefono = request.TelefonoProveedor;
                proveedor.Direccion = request.DireccionProveedor;

                _unitOfWork.ProveedorRepository.Edit(proveedor);
                _unitOfWork.Commit();
                return new UpdateProveedorResponse() { Mensaje = "Proveedor modificado correctamente" };
            }
            else
            {
                return new UpdateProveedorResponse() { Mensaje = "El proveedor no existe", Error = true };
            }
        }
    }
    public class UpdateProveedorRequest
    {
        public string CodigoProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string DireccionProveedor { get; set; }
    }

    public class UpdateProveedorResponse
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
