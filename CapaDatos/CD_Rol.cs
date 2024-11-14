using CapaEntidad;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Rol
    {
        /// <summary>
        /// Obtiene la lista de roles desde la base de datos.
        /// </summary>
        /// <returns>Lista de roles.</returns>
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            try
            {
                using (var conexion = new Conexion().ObtenerConexion())
                {
                    conexion.Open();

                    var query = new StringBuilder();
                    query.AppendLine("select IdRol, Descripcion from ROL");

                    var cmd = new MySqlCommand(query.ToString(), conexion)
                    {
                        CommandType = CommandType.Text
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                lista = new List<Rol>(); // En caso de error, retornamos una lista vacía
            }

            return lista;
        }
    }
}
