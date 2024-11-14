using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private readonly CD_Producto objcd_Producto = new CD_Producto();

        // Método para validar los campos comunes de un producto
        private bool ValidarProducto(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Codigo))
            {
                Mensaje += "Es necesario el codigo del Producto\n";
            }

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }

            if (string.IsNullOrEmpty(obj.Descripcion))
            {
                Mensaje += "Es necesario la Descripcion del Producto\n";
            }

            return string.IsNullOrEmpty(Mensaje); // Retorna true si no hay errores
        }

        // Listar productos
        public List<Producto> Listar()
        {
            try
            {
                return objcd_Producto.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: " + ex.Message);
            }
        }

        // Registrar un producto
        public int Registrar(Producto obj, out string Mensaje)
        {
            // Validar campos antes de registrar
            if (!ValidarProducto(obj, out Mensaje))
            {
                return 0; // Si hay errores en la validación, no continuar
            }

            try
            {
                return objcd_Producto.Registrar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al registrar el producto: " + ex.Message;
                return 0;
            }
        }

        // Editar un producto
        public bool Editar(Producto obj, out string Mensaje)
        {
            // Validar campos antes de editar
            if (!ValidarProducto(obj, out Mensaje))
            {
                return false; // Si hay errores en la validación, no continuar
            }

            try
            {
                return objcd_Producto.Editar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al editar el producto: " + ex.Message;
                return false;
            }
        }

        // Eliminar un producto
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            try
            {
                return objcd_Producto.Eliminar(obj, out Mensaje);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Mensaje = "Error al eliminar el producto: " + ex.Message;
                return false;
            }
        }
    }
}
