using System;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    struct Punto2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punto2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Mostrar()
        {
            Console.WriteLine($"({X}, {Y})");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           

            Console.WriteLine("Ingrese los datos del primer punto:");
            Console.Write("X: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            int y1 = int.Parse(Console.ReadLine());

            Punto2D punto1 = new Punto2D(x1, y1);


            Console.WriteLine("\nIngrese los datos del segundo punto:");
            Console.Write("X: ");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            int y2 = int.Parse(Console.ReadLine());

            Punto2D punto2 = new Punto2D(x2, y2);


            Console.WriteLine("\nIngrese los datos del tercer punto:");
            Console.Write("X: ");
            int x3 = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            int y3 = int.Parse(Console.ReadLine());

            Punto2D punto3 = new Punto2D(x3, y3);


            // Mostrar los puntos
            Console.WriteLine("\nPuntos ingresados:");

            punto1.Mostrar();
            punto2.Mostrar();
            punto3.Mostrar();


           

            string conexionMaster =
                @"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

            string conexionBD =
                @"Server=(localdb)\MSSQLLocalDB;Database=PuntosDB;Trusted_Connection=True;TrustServerCertificate=True;";


           

            using (SqlConnection conexion = new SqlConnection(conexionMaster))
            {
                conexion.Open();

                string crearBD = @"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PuntosDB')
                    BEGIN
                        CREATE DATABASE PuntosDB
                    END";

                SqlCommand comando = new SqlCommand(crearBD, conexion);
                comando.ExecuteNonQuery();
            }



            using (SqlConnection conexion = new SqlConnection(conexionBD))
            {
                conexion.Open();

                string crearTabla = @"
                    IF NOT EXISTS 
                    (
                        SELECT * 
                        FROM sysobjects 
                        WHERE name = 'Puntos' 
                        AND xtype = 'U'
                    )
                    BEGIN
                        CREATE TABLE Puntos
                        (
                            id INT PRIMARY KEY IDENTITY(1,1),
                            X INT,
                            Y INT
                        )
                    END";

                SqlCommand comando = new SqlCommand(crearTabla, conexion);
                comando.ExecuteNonQuery();
            }


           

            using (SqlConnection conexion = new SqlConnection(conexionBD))
            {
                conexion.Open();

                string insertar = @"
                    INSERT INTO Puntos (X, Y)
                    VALUES (@X, @Y)";

                SqlCommand comando = new SqlCommand(insertar, conexion);

                comando.Parameters.AddWithValue("@X", punto1.X);
                comando.Parameters.AddWithValue("@Y", punto1.Y);
                comando.ExecuteNonQuery();

                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@X", punto2.X);
                comando.Parameters.AddWithValue("@Y", punto2.Y);
                comando.ExecuteNonQuery();

                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@X", punto3.X);
                comando.Parameters.AddWithValue("@Y", punto3.Y);
                comando.ExecuteNonQuery();
            }


            

            Console.WriteLine("\nIngrese los nuevos datos para el tercer punto:");

            Console.Write("Nuevo X: ");
            int nuevoX = int.Parse(Console.ReadLine());

            Console.Write("Nuevo Y: ");
            int nuevoY = int.Parse(Console.ReadLine());


            using (SqlConnection conexion = new SqlConnection(conexionBD))
            {
                conexion.Open();

                string actualizar = @"
                    UPDATE Puntos
                    SET X = @X, Y = @Y
                    WHERE id = 3";

                SqlCommand comando = new SqlCommand(actualizar, conexion);

                comando.Parameters.AddWithValue("@X", nuevoX);
                comando.Parameters.AddWithValue("@Y", nuevoY);

                comando.ExecuteNonQuery();
            }


           

            using (SqlConnection conexion = new SqlConnection(conexionBD))
            {
                conexion.Open();

                string borrar = @"
                    DELETE FROM Puntos
                    WHERE id = 1";

                SqlCommand comando = new SqlCommand(borrar, conexion);

                comando.ExecuteNonQuery();
            }


            

            Console.WriteLine("\nPuntos que quedaron en la base de datos:");

            using (SqlConnection conexion = new SqlConnection(conexionBD))
            {
                conexion.Open();

                string consultar = @"
                    SELECT id, X, Y
                    FROM Puntos";

                SqlCommand comando = new SqlCommand(consultar, conexion);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Console.WriteLine(
                        $"ID: {lector["id"]} - ({lector["X"]}, {lector["Y"]})"
                    );
                }
            }

            Console.WriteLine("\nPresione una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
