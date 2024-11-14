using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Rol
    {
        private readonly CD_Rol objcd_rol = new CD_Rol();

        // Listar roles
        public List<Rol> Listar()
        {
            try
            {
                return objcd_rol.Listar();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener los roles: " + ex.Message);
            }
        }
    }
}
