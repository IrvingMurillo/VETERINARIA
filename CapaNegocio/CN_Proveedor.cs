using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private readonly CD_Proveedor objcd_Proveedor = new CD_Proveedor();

        // Método para validar los campos comunes
        private bool ValidarProveedor(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;  // Esta es la única asignación de Mensaje

            // Solo asignamos mensaje si hay un error
            if (string.IsNullOrEmpty(obj.Documento))
            {
                Mensaje += "Es necesario el documento del Proveedor\n";
            }

            if (string.IsNullOrEmpty(obj.RazonSocial))
            {
                Mensaje += "Es necesario la razon social del Proveedor\n";
            }

            if (string.IsNullOrEmpty(obj.Correo))
            {
                Mensaje += "Es necesario el correo del Proveedor\n";
            }

            // Retornar true si no hay errores en el mensaje
            return string.IsNullOrEmpty(Mensaje);
        }

        // Listar proveedores
        public List<Proveedor> Listar()
        {
            try
            {
                return objcd_Proveedor.Listar();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones en caso de que falle la llamada a la capa de datos
                throw new Exception("Error al obtener los proveedores: " + ex.Message);
            }
        }

        // Registrar proveedor
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            // Ahora no asignamos inicialmente a Mensaje, solo cuando es necesario
            if (!ValidarProveedor(obj, out Mensaje))
            {
                return 0;  // Si hay errores en la validación, no continuar
            }

            try
            {
                return objcd_Proveedor.Registrar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al registrar el proveedor: " + ex.Message;
                return 0;
            }
        }

        // Editar proveedor
        public bool Editar(Proveedor obj, out string Mensaje)
        {
            if (!ValidarProveedor(obj, out Mensaje))
            {
                return false;  // Si hay errores en la validación, no continuar
            }

            try
            {
                return objcd_Proveedor.Editar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al editar el proveedor: " + ex.Message;
                return false;
            }
        }

        // Eliminar proveedor
        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            try
            {
                return objcd_Proveedor.Eliminar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al eliminar el proveedor: " + ex.Message;
                return false;
            }
        }
    }
}
