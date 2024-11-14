using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private readonly CD_Usuario objcd_usuario = new CD_Usuario();

        // Método para validar los campos comunes de un usuario
        private bool ValidarUsuario(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Documento))
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }

            if (string.IsNullOrEmpty(obj.NombreCompleto))
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (string.IsNullOrEmpty(obj.Clave))
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }

            return string.IsNullOrEmpty(Mensaje);
        }

        // Listar usuarios
        public List<Usuario> Listar()
        {
            try
            {
                return objcd_usuario.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios: " + ex.Message);
            }
        }

        // Registrar un nuevo usuario
        public int Registrar(Usuario obj, out string Mensaje)
        {
            // Eliminar la asignación innecesaria
            if (!ValidarUsuario(obj, out Mensaje))
            {
                return 0;  // Si hay errores en la validación, no continuar
            }

            try
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al registrar el usuario: " + ex.Message;
                return 0;
            }
        }

        // Editar un usuario
        public bool Editar(Usuario obj, out string Mensaje)
        {
            // Eliminar la asignación innecesaria
            if (!ValidarUsuario(obj, out Mensaje))
            {
                return false;  // Si hay errores en la validación, no continuar
            }

            try
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al editar el usuario: " + ex.Message;
                return false;
            }
        }

        // Eliminar un usuario
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            try
            {
                return objcd_usuario.Eliminar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al eliminar el usuario: " + ex.Message;
                return false;
            }
        }
    }
}
