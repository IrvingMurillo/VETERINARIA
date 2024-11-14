using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Permiso
    {
        /// <summary>
        /// Obtiene la lista de permisos de un usuario basado en su ID.
        /// </summary>
        /// <param name="idusuario">ID del usuario para obtener sus permisos.</param>
        /// <returns>Lista de permisos asociados al usuario.</returns>
        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> lista = new List<Permiso>();

            try
            {
                using (var conexion = new Conexion().ObtenerConexion())
                {
                    conexion.Open();

                    var query = new StringBuilder();
                    query.AppendLine("SELECT p.IdRol, p.NombreMenu FROM PERMISO p");
                    query.AppendLine("INNER JOIN ROL r ON r.IdRol = p.IdRol");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdRol = r.IdRol");
                    query.AppendLine("WHERE u.IdUsuario = @idusuario");

                    var cmd = new MySqlCommand(query.ToString(), conexion)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                Rol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["NombreMenu"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                lista = new List<Permiso>(); // Devuelve lista vacía en caso de error
            }

            return lista;
        }
    }
}
