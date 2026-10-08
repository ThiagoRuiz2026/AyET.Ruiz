using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pais { get; set; }
        public string Posicion { get; set; }
        public int Goles { get; set; }
        public int MundialesJugados { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | {Nombre} {Apellido} ({Pais}) - Posición: {Posicion} | Goles: {Goles} | Mundiales: {MundialesJugados}";
        }
    }

    public class Nodo
    {
        public Jugador Jugador;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(Jugador jugador)
        {
            Jugador = jugador;
            Izquierdo = null;
            Derecho = null;
        }
    }

    public class ArbolBinarioBusqueda
    {
        public Nodo Raiz;

        public void Insertar(Jugador jugador)
        {
            Raiz = InsertarRec(Raiz, jugador);
        }

        private Nodo InsertarRec(Nodo raiz, Jugador jugador)
        {
            if (raiz == null)
            {
                raiz = new Nodo(jugador);
                return raiz;
            }

            if (jugador.Goles < raiz.Jugador.Goles)
                raiz.Izquierdo = InsertarRec(raiz.Izquierdo, jugador);
            else
                raiz.Derecho = InsertarRec(raiz.Derecho, jugador);

            return raiz;
        }

        public Jugador BuscarPorGoles(Nodo raiz, int goles)
        {
            if (raiz == null || raiz.Jugador.Goles == goles)
                return raiz?.Jugador;

            if (goles < raiz.Jugador.Goles)
                return BuscarPorGoles(raiz.Izquierdo, goles);

            return BuscarPorGoles(raiz.Derecho, goles);
        }
    }

    internal class Program
    {
        private static string cadenaConexion = "Server=localhost;Database=jugadores;Uid=root;Pwd=;";

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" SISTEMA DE JUGADORES - TRABAJO PRÁCTICO");
                Console.WriteLine("");
                Console.WriteLine("1. Ver lista de jugadores (BD)");
                Console.WriteLine("2. Agregar un nuevo jugador (BD)");
                Console.WriteLine("3. Eliminar un jugador por ID (BD)");
                Console.WriteLine("4. Ordenar por Nombre (Algoritmo Burbuja)");
                Console.WriteLine("5. Ordenar por Mundiales Jugados (Algoritmo Burbuja)");
                Console.WriteLine("6. Buscar jugador en Árbol Binario por Goles");
                Console.WriteLine("7. Salir");
                Console.WriteLine("");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();
                List<Jugador> lista = CargarDatosDesdeBD();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n LISTA DE JUGADORES EN LA BD ");
                        foreach (var j in lista) Console.WriteLine(j);
                        break;

                    case "2":
                        Console.WriteLine("\n AGREGAR NUEVO JUGADOR ");
                        Jugador nuevo = new Jugador();
                        Console.Write("Nombre: "); nuevo.Nombre = Console.ReadLine();
                        Console.Write("Apellido: "); nuevo.Apellido = Console.ReadLine();
                        Console.Write("País: "); nuevo.Pais = Console.ReadLine();
                        Console.Write("Posición: "); nuevo.Posicion = Console.ReadLine();
                        Console.Write("Goles: "); nuevo.Goles = int.Parse(Console.ReadLine());
                        Console.Write("Mundiales Jugados: "); nuevo.MundialesJugados = int.Parse(Console.ReadLine());

                        AgregarJugador(nuevo);
                        Console.WriteLine("¡Jugador guardado en la base de datos con éxito!");
                        break;

                    case "3":
                        Console.Write("\nIngrese el ID del jugador a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        EliminarJugador(idEliminar);
                        Console.WriteLine("Jugador eliminado con éxito.");
                        break;

                    case "4":
                        OrdenarPorNombreBurbuja(lista);
                        Console.WriteLine("\n--- JUGADORES ORDENADOS ALFABÉTICAMENTE POR NOMBRE ---");
                        foreach (var j in lista) Console.WriteLine(j);
                        break;

                    case "5":
                        OrdenarPorMundialesBurbuja(lista);
                        Console.WriteLine("\n--- JUGADORES ORDENADOS POR MUNDIALES JUGADOS ---");
                        foreach (var j in lista) Console.WriteLine(j);
                        break;

                    case "6":
                        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
                        foreach (var j in lista) arbol.Insertar(j);

                        Console.Write("\nIngrese la cantidad de goles a buscar en el Árbol: ");
                        int golesBusqueda = int.Parse(Console.ReadLine());
                        Jugador hallado = arbol.BuscarPorGoles(arbol.Raiz, golesBusqueda);

                        if (hallado != null)
                            Console.WriteLine($"\n¡Encontrado en el Árbol!: {hallado}");
                        else
                            Console.WriteLine("\nNo se encontró ningún jugador con esa cantidad de goles.");
                        break;

                    case "7":
                        salir = true;
                        Console.WriteLine("\nSaliendo del programa...");
                        continue;

                    default:
                        Console.WriteLine("\nOpción inválida. Presione una tecla para reintentar.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                Console.ReadKey();
            }
        }

        //  MeTODOS DE BASE DE DATOS Y LoGICA 

        public static List<Jugador> CargarDatosDesdeBD()
        {
            List<Jugador> lista = new List<Jugador>();
            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM goleadores_mundial";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new Jugador
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            Pais = reader["pais"].ToString(),
                            Posicion = reader["posicion"].ToString(),
                            Goles = Convert.ToInt32(reader["goles"]),
                            MundialesJugados = Convert.ToInt32(reader["mundiales_jugados"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de conexión: " + ex.Message);
                }
            }
            return lista;
        }

        public static void AgregarJugador(Jugador j)
        {
            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                conn.Open();
                string query = "INSERT INTO goleadores_mundial (nombre, apellido, pais, posicion, goles, mundiales_jugados) VALUES (@nombre, @apellido, @pais, @posicion, @goles, @mundiales)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", j.Nombre);
                cmd.Parameters.AddWithValue("@apellido", j.Apellido);
                cmd.Parameters.AddWithValue("@pais", j.Pais);
                cmd.Parameters.AddWithValue("@posicion", j.Posicion);
                cmd.Parameters.AddWithValue("@goles", j.Goles);
                cmd.Parameters.AddWithValue("@mundiales", j.MundialesJugados);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarJugador(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                conn.Open();
                string query = "DELETE FROM goleadores_mundial WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void OrdenarPorNombreBurbuja(List<Jugador> lista)
        {
            int n = lista.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(lista[j].Nombre, lista[j + 1].Nombre) > 0)
                    {
                        var temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }
        }

        public static void OrdenarPorMundialesBurbuja(List<Jugador> lista)
        {
            int n = lista.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (lista[j].MundialesJugados < lista[j + 1].MundialesJugados)
                    {
                        var temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }
        }
    }
}

