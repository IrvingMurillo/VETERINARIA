using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Negocio
    {
        /// <summary>
        /// Obtiene los datos del negocio (nombre, RUC, dirección, etc.).
        /// </summary>
        /// <returns>Objeto de tipo Negocio con los datos del negocio.</returns>
        public Negocio ObtenerDatos()
        {
            var obj = new Negocio();

            try
            {
                using (var conexion = new Conexion().ObtenerConexion())
                {
                    conexion.Open();

                    var query = "SELECT IdNegocio, Nombre, RUC, Direccion FROM NEGOCIO WHERE IdNegocio = 1";
                    var cmd = new MySqlCommand(query, conexion)
                    {
                        CommandType = CommandType.Text
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RUC = dr["RUC"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            catch
            {
                obj = new Negocio(); // Devuelve un objeto vacío en caso de error
            }

            return obj;
        }

        /// <summary>
        /// Guarda los datos del negocio en la base de datos.
        /// </summary>
        /// <param name="objeto">Objeto de tipo Negocio con los datos a guardar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>True si los datos fueron guardados exitosamente, de lo contrario false.</returns>
        public bool GuardarDatos(Negocio objeto, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (var conexion = new Conexion().ObtenerConexion())
                {
                    conexion.Open();

                    var query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Nombre = @nombre,");
                    query.AppendLine("RUC = @ruc,");
                    query.AppendLine("Direccion = @direccion");
                    query.AppendLine("WHERE IdNegocio = 1;");

                    var cmd = new MySqlCommand(query.ToString(), conexion)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@ruc", objeto.RUC);
                    cmd.Parameters.AddWithValue("@direccion", objeto.Direccion);

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo guardar los datos";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        /// <summary>
        /// Obtiene el logo del negocio en formato byte[].
        /// </summary>
        /// <param name="obtenido">Indica si se pudo obtener el logo correctamente.</param>
        /// <returns>Logo en formato byte[]</returns>
        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] logoBytes = new byte[0];

            try
            {
                using (var conexion = new Conexion().ObtenerConexion())
                {
                    conexion.Open();

                    var query = "SELECT Logo FROM NEGOCIO WHERE IdNegocio = 1";
                    var cmd = new MySqlCommand(query, conexion)
                    {
                        CommandType = CommandType.Text
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            logoBytes = (byte[])dr["Logo"];
                        }
                    }
                }
            }
            catch (Exception)
            {
                obtenido = false;
                logoBytes = new byte[0];
            }

            return logoBytes;
        }

        /// <summary>
        /// Actualiza el logo del negocio en la base de datos.
        /// </summary>
        /// <param name="image">Imagen del logo en formato byte[].</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>True si el logo fue actualizado correctamente, de lo contrario false.</returns>
        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (var conexion = new Conexion().ObtenerConexion())
                {
                    conexion.Open();

                    var query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Logo = @imagen");
                    query.AppendLine("WHERE IdNegocio = 1;");

                    var cmd = new MySqlCommand(query.ToString(), conexion)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.AddWithValue("@imagen", image);

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}
