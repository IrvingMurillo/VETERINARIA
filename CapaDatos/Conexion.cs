using MySql.Data.MySqlClient;
using System;

namespace CapaDatos
{
    public class Conexion
    {
        private readonly MySqlConnection connection;

        // Constructor
        public Conexion()
        {
            // Cadena de conexión
            string connectionString = "Server=localhost;Port=3306;Database=veterinaria_db;Uid=root;Pwd=P@ssw0rdT3st!;";
            connection = new MySqlConnection(connectionString);
        }

        // Método para abrir la conexión
        public void AbrirConexion()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta exitosamente.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void CerrarConexion()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada exitosamente.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }

        // Método para obtener la conexión
        public MySqlConnection ObtenerConexion()
        {
            return connection;
        }
    }
}
