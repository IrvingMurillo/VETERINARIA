using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private readonly CD_Cliente objcd_Cliente = new CD_Cliente();

        // Método para validar los datos del cliente
        private bool ValidarCliente(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Documento))
                mensaje += "Es necesario el documento del Cliente\n";

            if (string.IsNullOrEmpty(obj.NombreCompleto))
                mensaje += "Es necesario el nombre completo del Cliente\n";

            if (string.IsNullOrEmpty(obj.Correo))
                mensaje += "Es necesario el correo del Cliente\n";

            return string.IsNullOrEmpty(mensaje); // Si el mensaje sigue vacío, la validación fue exitosa
        }

        // Listar clientes
        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();
        }

        // Registrar cliente
        public int Registrar(Cliente obj, out string Mensaje)
        {
            if (!ValidarCliente(obj, out Mensaje))
                return 0; // Si la validación falla, retorna 0

            try
            {
                return objcd_Cliente.Registrar(obj, out Mensaje); // Llamada a la capa de datos
            }
            catch (Exception ex)
            {
                Mensaje = $"Error al registrar el cliente: {ex.Message}";
                return 0;
            }
        }

        // Editar cliente
        public bool Editar(Cliente obj, out string Mensaje)
        {
            if (!ValidarCliente(obj, out Mensaje))
                return false; // Si la validación falla, retorna false

            try
            {
                return objcd_Cliente.Editar(obj, out Mensaje); // Llamada a la capa de datos
            }
            catch (Exception ex)
            {
                Mensaje = $"Error al editar el cliente: {ex.Message}";
                return false;
            }
        }

        // Eliminar cliente
        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            try
            {
                return objcd_Cliente.Eliminar(obj, out Mensaje); // Llamada a la capa de datos
            }
            catch (Exception ex)
            {
                Mensaje = $"Error al eliminar el cliente: {ex.Message}";
                return false;
            }
        }
    }
}
