using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private readonly CD_Reporte objcd_reporte = new CD_Reporte();

        // Reporte de compras
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            try
            {
                return objcd_reporte.Compra(fechainicio, fechafin, idproveedor);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el reporte de compras: " + ex.Message);
            }
        }

        // Reporte de ventas
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            try
            {
                return objcd_reporte.Venta(fechainicio, fechafin);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el reporte de ventas: " + ex.Message);
            }
        }
    }
}
