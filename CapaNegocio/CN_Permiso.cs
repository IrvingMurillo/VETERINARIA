using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private readonly CD_Permiso objcd_permiso = new CD_Permiso();

        // Obtener la lista de permisos para un usuario específico
        public List<Permiso> Listar(int IdUsuario)
        {
            try
            {
                return objcd_permiso.Listar(IdUsuario);
            }
            catch (Exception ex)
            {
                // En caso de error, lanzar una excepción con un mensaje detallado
                throw new Exception("Error al obtener los permisos del usuario: " + ex.Message);
            }
        }
    }
}
