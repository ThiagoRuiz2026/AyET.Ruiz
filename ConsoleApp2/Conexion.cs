using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    public class Conexion
    {
        private string cadena = "Server=127.0.0.1;Port=3306;Database=pokedex;Uid=root;Pwd=;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadena);
        }

        public bool ProbarConexion()
        {
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return false;
            }
        }
    }
}
