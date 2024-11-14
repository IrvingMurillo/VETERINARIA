using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private readonly CD_Compra objcd_compra = new CD_Compra();

        // Obtener el correlativo
        public int ObtenerCorrelativo()
        {
            try
            {
                return objcd_compra.ObtenerCorrelativo();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el correlativo: " + ex.Message);
            }
        }

        // Registrar compra
        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            try
            {
                return objcd_compra.Registrar(obj, DetalleCompra, out Mensaje);
            }
            catch (Exception ex)
            {
                Mensaje = "Error al registrar la compra: " + ex.Message;
                return false;
            }
        }

        // Obtener compra
        public Compra ObtenerCompra(string numero)
        {
            try
            {
                Compra oCompra = objcd_compra.ObtenerCompra(numero);

                if (oCompra.IdCompra != 0)
                {
                    List<Detalle_Compra> oDetalleCompra = objcd_compra.ObtenerDetalleCompra(oCompra.IdCompra);
                    oCompra.DetalleCompra = oDetalleCompra;
                }

                return oCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la compra: " + ex.Message);
            }
        }
    }
}
