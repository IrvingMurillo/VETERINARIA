using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Categoria
    {
        /// <summary>
        /// Obtiene una lista de todas las categorías en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos de tipo Categoria.</returns>
        public List<Categoria> Listar()
        {
            var lista = new List<Categoria>();

            // Establece y usa la conexión a la base de datos
            using (var oconexion = new Conexion().ObtenerConexion())
            {
                try
                {
                    // Define la consulta SQL para obtener todas las categorías
                    var query = new StringBuilder("SELECT IdCategoria, Descripcion, Estado FROM CATEGORIA");
                    var cmd = new MySqlCommand(query.ToString(), oconexion)
                    {
                        CommandType = CommandType.Text
                    };

                    // Abre la conexión y ejecuta el comando
                    oconexion.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        // Lee los resultados y llena la lista de categorías
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Reinicia la lista en caso de error y opcionalmente imprime el error
                    lista.Clear();
                    Console.WriteLine($"Error en Listar: {ex.Message}");
                }
            }

            return lista;
        }

        /// <summary>
        /// Registra una nueva categoría en la base de datos.
        /// </summary>
        /// <param name="obj">Objeto Categoria a registrar.</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>Id de la categoría generada, o 0 en caso de error.</returns>
        public int Registrar(Categoria obj, out string Mensaje)
        {
            int idCategoriagenerado = 0;
            Mensaje = string.Empty;

            try
            {
                // Configura y ejecuta el procedimiento almacenado para registrar la categoría
                using (var oconexion = new Conexion().ObtenerConexion())
                {
                    var cmd = new MySqlCommand("SP_RegistrarCategoria", oconexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Agrega parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Recupera valores de salida
                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                // Manejo de error y asignación de mensaje de salida
                idCategoriagenerado = 0;
                Mensaje = ex.Message;
            }

            return idCategoriagenerado;
        }

        /// <summary>
        /// Edita una categoría existente en la base de datos.
        /// </summary>
        /// <param name="obj">Objeto Categoria con los datos actualizados.</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si la operación fue exitosa, False si hubo un error.</returns>
        public bool Editar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                // Configura y ejecuta el procedimiento almacenado para editar la categoría
                using (var oconexion = new Conexion().ObtenerConexion())
                {
                    var cmd = new MySqlCommand("sp_EditarCategoria", oconexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Agrega parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Recupera valores de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                // Manejo de error y asignación de mensaje de salida
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        /// <summary>
        /// Elimina una categoría de la base de datos.
        /// </summary>
        /// <param name="obj">Objeto Categoria con el Id de la categoría a eliminar.</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si la operación fue exitosa, False si hubo un error.</returns>
        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                // Configura y ejecuta el procedimiento almacenado para eliminar la categoría
                using (var oconexion = new Conexion().ObtenerConexion())
                {
                    var cmd = new MySqlCommand("sp_EliminarCategoria", oconexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Agrega parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Recupera valores de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                // Manejo de error y asignación de mensaje de salida
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
