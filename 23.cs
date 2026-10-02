
using System;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    struct Producto
    {
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, int codigo, double precio)
        {
            Nombre = nombre;
            Codigo = codigo;
            Precio = precio;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear array con capacidad para 3 productos
            Producto[] productos = new Producto[3];

            // Cargar los 3 productos
            productos[0] = new Producto("Teclado", 101, 25000);
            productos[1] = new Producto("Mouse", 102, 15000);
            productos[2] = new Producto("Auriculares", 103, 30000);

            // Mostrar los productos usando foreach
            Console.WriteLine("INVENTARIO");

            foreach (Producto producto in productos)
            {
                Console.WriteLine(
                    $"Nombre: {producto.Nombre} - Precio: ${producto.Precio}"
                );
            }


            string conexionMaster =
                @"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

            string conexionBD =
                @"Server=(localdb)\MSSQLLocalDB;Database=InventarioDB;Trusted_Connection=True;TrustServerCertificate=True;";



            using (SqlConnection conexion = new SqlConnection(conexionMaster))
            {
                conexion.Open();

                string crearBD = @"
                    IF NOT EXISTS
                    (
                        SELECT name
                        FROM sys.databases
                        WHERE name = 'InventarioDB'
                    )
                    BEGIN
                        CREATE DATABASE InventarioDB
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
                        WHERE name = 'Productos'
                        AND xtype = 'U'
                    )
                    BEGIN
                        CREATE TABLE Productos
                        (
                            id INT PRIMARY KEY IDENTITY(1,1),
                            Nombre VARCHAR(100),
                            Codigo INT,
                            Precio FLOAT
                        )
                    END";

                SqlCommand comando = new SqlCommand(crearTabla, conexion);
                comando.ExecuteNonQuery();
            }


            using (SqlConnection conexion = new SqlConnection(conexionBD))
            {
                conexion.Open();

                foreach (Producto producto in productos)
                {
                    string insertar = @"
                        INSERT INTO Productos (Nombre, Codigo, Precio)
                        VALUES (@Nombre, @Codigo, @Precio)";

                    SqlCommand comando = new SqlCommand(insertar, conexion);

                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);

                    comando.ExecuteNonQuery();
                }
            }

            Console.WriteLine("\nLos productos fueron guardados en la base de datos.");

            Console.WriteLine("\nPresione una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}

