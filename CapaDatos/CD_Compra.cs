using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class CD_Compra
    {
        /// <summary>
        /// Obtiene el correlativo de la tabla COMPRA.
        /// </summary>
        /// <returns>El número de correlativo de la próxima compra.</returns>
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (var oconexion = new Conexion().ObtenerConexion())
            {
                try
                {
                    var query = new StringBuilder("SELECT COUNT(*) + 1 FROM COMPRA");
                    var cmd = new MySqlCommand(query.ToString(), oconexion)
                    {
                        CommandType = CommandType.Text
                    };

                    oconexion.Open();
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    idcorrelativo = 0; // Valor predeterminado en caso de error
                }
            }

            return idcorrelativo;
        }

        /// <summary>
        /// Registra una nueva compra en la base de datos.
        /// </summary>
        /// <param name="obj">Objeto de la compra.</param>
        /// <param name="DetalleCompra">Detalles de la compra como DataTable.</param>
        /// <param name="Mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>True si el registro fue exitoso; de lo contrario, false.</returns>
        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            using (var oconexion = new Conexion().ObtenerConexion())
            {
                try
                {
                    var cmd = new MySqlCommand("sp_RegistrarCompra", oconexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("IdUsuario", obj.Usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.Proveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);

                    // Parámetros de salida
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return Respuesta;
        }

        /// <summary>
        /// Obtiene una compra específica por número de documento.
        /// </summary>
        /// <param name="numero">Número de documento de la compra.</param>
        /// <returns>Objeto de tipo Compra con los datos obtenidos.</returns>
        public Compra ObtenerCompra(string numero)
        {
            var obj = new Compra();

            using (var oconexion = new Conexion().ObtenerConexion())
            {
                try
                {
                    var query = new StringBuilder();
                    query.AppendLine("SELECT c.IdCompra,");
                    query.AppendLine("u.NombreCompleto,");
                    query.AppendLine("pr.Documento, pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento, c.NumeroDocumento, c.MontoTotal, DATE_FORMAT(c.FechaRegistro, '%d/%m/%Y') AS FechaRegistro");
                    query.AppendLine("FROM COMPRA c");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = c.IdUsuario");
                    query.AppendLine("INNER JOIN PROVEEDOR pr ON pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("WHERE c.NumeroDocumento = @numero");

                    var cmd = new MySqlCommand(query.ToString(), oconexion)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.AddWithValue("@numero", numero);

                    oconexion.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                Usuario = new Usuario { NombreCompleto = dr["NombreCompleto"].ToString() },
                                Proveedor = new Proveedor
                                {
                                    Documento = dr["Documento"].ToString(),
                                    RazonSocial = dr["RazonSocial"].ToString()
                                },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    obj = new Compra(); // Devuelve un objeto vacío en caso de error
                }
            }

            return obj;
        }

        /// <summary>
        /// Obtiene el detalle de una compra específica.
        /// </summary>
        /// <param name="idcompra">ID de la compra.</param>
        /// <returns>Lista de detalles de compra.</returns>
        public List<Detalle_Compra> ObtenerDetalleCompra(int idcompra)
        {
            var oLista = new List<Detalle_Compra>();

            try
            {
                using (var conexion = new Conexion().ObtenerConexion())
                {
                    conexion.Open();

                    var query = new StringBuilder();
                    query.AppendLine("SELECT p.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal FROM DETALLE_COMPRA dc");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto");
                    query.AppendLine("WHERE dc.IdCompra = @idcompra");

                    var cmd = new MySqlCommand(query.ToString(), conexion)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Compra
                            {
                                Producto = new Producto { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"])
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                oLista.Clear(); // Reinicia la lista en caso de error
            }

            return oLista;
        }
    }
}
