using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Cliente
    {
        /// <summary>
        /// Obtiene la lista de clientes desde la base de datos.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public List<Cliente> Listar()
        {
            var lista = new List<Cliente>();

            using (var oconexion = new Conexion().ObtenerConexion())
            {
                try
                {
                    var query = new StringBuilder("SELECT IdCliente, Documento, NombreCompleto, Correo, Telefono, Estado FROM CLIENTE");
                    var cmd = new MySqlCommand(query.ToString(), oconexion)
                    {
                        CommandType = CommandType.Text
                    };

                    oconexion.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista.Clear(); // Reinicia la lista en caso de error
                }
            }

            return lista;
        }

        /// <summary>
        /// Registra un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="obj">Objeto cliente a registrar.</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>El ID del cliente registrado.</returns>
        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (var oconexion = new Conexion().ObtenerConexion())
                {
                    var cmd = new MySqlCommand("SP_RegistrarCliente", oconexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    // Asigna resultados de los parámetros de salida
                    idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }

            return idClientegenerado;
        }

        /// <summary>
        /// Modifica los datos de un cliente en la base de datos.
        /// </summary>
        /// <param name="obj">Objeto cliente con datos actualizados.</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si la edición fue exitosa, de lo contrario false.</returns>
        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (var oconexion = new Conexion().ObtenerConexion())
                {
                    var cmd = new MySqlCommand("sp_EditarCliente", oconexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    // Asigna resultados de los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        /// <summary>
        /// Elimina un cliente de la base de datos.
        /// </summary>
        /// <param name="obj">Objeto cliente a eliminar.</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si la eliminación fue exitosa, de lo contrario false.</returns>
        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (var oconexion = new Conexion().ObtenerConexion())
                {
                    var cmd = new MySqlCommand("DELETE FROM CLIENTE WHERE IdCliente = @id", oconexion)
                    {
                        CommandType = CommandType.Text
                    };

                    // Parámetro de entrada
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);

                    oconexion.Open();

                    // Ejecuta y verifica si se eliminaron filas
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
