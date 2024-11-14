using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private readonly CD_Negocio objcd_negocio = new CD_Negocio();

        // Obtener los datos del negocio
        public Negocio ObtenerDatos()
        {
            try
            {
                return objcd_negocio.ObtenerDatos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos del negocio: " + ex.Message);
            }
        }

        // Guardar los datos del negocio con validación
        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validación de datos
            if (string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre\n";
            }

            if (string.IsNullOrEmpty(obj.RUC))
            {
                Mensaje += "Es necesario el numero de RUC\n";
            }

            if (string.IsNullOrEmpty(obj.Direccion))
            {
                Mensaje += "Es necesario la direccion\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                try
                {
                    return objcd_negocio.GuardarDatos(obj, out Mensaje);
                }
                catch (Exception ex)
                {
                    Mensaje = "Error al guardar los datos: " + ex.Message;
                    return false;
                }
            }
        }

        // Obtener el logo del negocio
        public byte[] ObtenerLogo(out bool obtenido)
        {
            try
            {
                return objcd_negocio.ObtenerLogo(out obtenido);
            }
            catch (Exception ex)
            {
                obtenido = false;
                throw new Exception("Error al obtener el logo: " + ex.Message);
            }
        }

        // Actualizar el logo del negocio
        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            try
            {
                return objcd_negocio.ActualizarLogo(imagen, out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar el logo: " + ex.Message;
                return false;
            }
        }
    }
}
