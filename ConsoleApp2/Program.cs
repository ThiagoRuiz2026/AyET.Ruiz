using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static Conexion conexion = new Conexion();
        static ArbolBinario arbol = new ArbolBinario();

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine(" POKEDEX");
            Console.WriteLine("");

            if (conexion.ProbarConexion())
            {
                Console.WriteLine("Conexion a la base de datos correcta.");
            }
            else
            {
                Console.WriteLine("No se pudo conectar a la base de datos.");
                Console.ReadKey();
                return;
            }

            Menu();
        }

        static void Menu()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("");
                Console.WriteLine(" POKEDEX");
                Console.WriteLine("");
                Console.WriteLine("1. Consultar pokemons");
                Console.WriteLine("2. Agregar pokemon");
                Console.WriteLine("3. Actualizar pokemon");
                Console.WriteLine("4. Eliminar pokemon");
                Console.WriteLine("5. Crear arbol binario");
                Console.WriteLine("6. Buscar pokemon en el arbol");
                Console.WriteLine("7. Mostrar arbol");
                Console.WriteLine("0. Salir");
                Console.WriteLine("");
                Console.Write("Seleccione una opcion: ");

                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        ConsultarPokemons();
                        break;

                    case 2:
                        AgregarPokemon();
                        break;

                    case 3:
                        ActualizarPokemon();
                        break;

                    case 4:
                        EliminarPokemon();
                        break;

                    case 5:
                        CrearArbol();
                        break;

                    case 6:
                        BuscarEnArbol();
                        break;

                    case 7:
                        MostrarArbol();
                        break;

                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        Pausa();
                        break;
                }

            } while (opcion != 0);
        }

        static void ConsultarPokemons()
        {
            Console.Clear();

            string sql = "SELECT * FROM pokemon";

            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, con))
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Pokemon pokemon = LeerPokemon(lector);
                            pokemon.Mostrar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Pausa();
        }

        static void AgregarPokemon()
        {
            Console.Clear();

            Pokemon pokemon = PedirDatosPokemon();

            string sql = @"INSERT INTO pokemon
                (id, nombre, tipo_1, tipo_2, hp, ataque, defensa,
                ataque_especial, defensa_especial, velocidad, nivel)
                VALUES
                (@id, @nombre, @tipo1, @tipo2, @hp, @ataque, @defensa,
                @ataqueEspecial, @defensaEspecial, @velocidad, @nivel)";

            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, con))
                    {
                        AgregarParametros(comando, pokemon);

                        comando.ExecuteNonQuery();

                        Console.WriteLine("Pokemon agregado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Pausa();
        }

        static void ActualizarPokemon()
        {
            Console.Clear();

            Console.Write("Ingrese el ID del pokemon a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            Pokemon pokemon = PedirDatosPokemon();

            pokemon.Id = id;

            string sql = @"UPDATE pokemon SET
                nombre = @nombre,
                tipo_1 = @tipo1,
                tipo_2 = @tipo2,
                hp = @hp,
                ataque = @ataque,
                defensa = @defensa,
                ataque_especial = @ataqueEspecial,
                defensa_especial = @defensaEspecial,
                velocidad = @velocidad,
                nivel = @nivel
                WHERE id = @id";

            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, con))
                    {
                        AgregarParametros(comando, pokemon);

                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            Console.WriteLine("Pokemon actualizado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No existe un pokemon con ese ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Pausa();
        }

        static void EliminarPokemon()
        {
            Console.Clear();

            Console.Write("Ingrese el ID del pokemon a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            string sql = "DELETE FROM pokemon WHERE id = @id";

            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, con))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            Console.WriteLine("Pokemon eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No existe un pokemon con ese ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Pausa();
        }

        static void CrearArbol()
        {
            Console.Clear();

            arbol.Vaciar();

            string sql = "SELECT * FROM pokemon";

            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, con))
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Pokemon pokemon = LeerPokemon(lector);
                            arbol.Insertar(pokemon);
                        }
                    }
                }

                Console.WriteLine("Arbol creado correctamente.");
                Console.WriteLine("Los pokemons fueron cargados desde la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Pausa();
        }

        static void BuscarEnArbol()
        {
            Console.Clear();

            Console.Write("Ingrese el ID del pokemon que desea buscar: ");
            int id = int.Parse(Console.ReadLine());

            Pokemon pokemon = arbol.Buscar(id);

            if (pokemon != null)
            {
                Console.WriteLine();
                Console.WriteLine("Pokemon encontrado:");
                pokemon.Mostrar();
            }
            else
            {
                Console.WriteLine("No se encontro el pokemon en el arbol.");
            }

            Pausa();
        }

        static void MostrarArbol()
        {
            Console.Clear();

            Console.WriteLine("Pokemon del arbol:");
            Console.WriteLine();

            arbol.Mostrar();

            Pausa();
        }

        static Pokemon LeerPokemon(MySqlDataReader lector)
        {
            return new Pokemon
            {
                Id = lector.GetInt32("id"),
                Nombre = lector.GetString("nombre"),
                Tipo1 = lector.GetString("tipo_1"),
                Tipo2 = lector.IsDBNull(lector.GetOrdinal("tipo_2"))
                    ? null
                    : lector.GetString("tipo_2"),
                Hp = lector.GetInt32("hp"),
                Ataque = lector.GetInt32("ataque"),
                Defensa = lector.GetInt32("defensa"),
                AtaqueEspecial = lector.GetInt32("ataque_especial"),
                DefensaEspecial = lector.GetInt32("defensa_especial"),
                Velocidad = lector.GetInt32("velocidad"),
                Nivel = lector.GetInt32("nivel")
            };
        }

        static Pokemon PedirDatosPokemon()
        {
            Pokemon pokemon = new Pokemon();

            Console.Write("ID: ");
            pokemon.Id = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            pokemon.Nombre = Console.ReadLine();

            Console.Write("Tipo 1: ");
            pokemon.Tipo1 = Console.ReadLine();

            Console.Write("Tipo 2 (dejar vacio si no tiene): ");
            pokemon.Tipo2 = Console.ReadLine();

            if (pokemon.Tipo2 == "")
            {
                pokemon.Tipo2 = null;
            }

            Console.Write("HP: ");
            pokemon.Hp = int.Parse(Console.ReadLine());

            Console.Write("Ataque: ");
            pokemon.Ataque = int.Parse(Console.ReadLine());

            Console.Write("Defensa: ");
            pokemon.Defensa = int.Parse(Console.ReadLine());

            Console.Write("Ataque especial: ");
            pokemon.AtaqueEspecial = int.Parse(Console.ReadLine());

            Console.Write("Defensa especial: ");
            pokemon.DefensaEspecial = int.Parse(Console.ReadLine());

            Console.Write("Velocidad: ");
            pokemon.Velocidad = int.Parse(Console.ReadLine());

            Console.Write("Nivel: ");
            pokemon.Nivel = int.Parse(Console.ReadLine());

            return pokemon;
        }

        static void AgregarParametros(MySqlCommand comando, Pokemon pokemon)
        {
            comando.Parameters.AddWithValue("@id", pokemon.Id);
            comando.Parameters.AddWithValue("@nombre", pokemon.Nombre);
            comando.Parameters.AddWithValue("@tipo1", pokemon.Tipo1);
            comando.Parameters.AddWithValue("@tipo2", pokemon.Tipo2);
            comando.Parameters.AddWithValue("@hp", pokemon.Hp);
            comando.Parameters.AddWithValue("@ataque", pokemon.Ataque);
            comando.Parameters.AddWithValue("@defensa", pokemon.Defensa);
            comando.Parameters.AddWithValue("@ataqueEspecial", pokemon.AtaqueEspecial);
            comando.Parameters.AddWithValue("@defensaEspecial", pokemon.DefensaEspecial);
            comando.Parameters.AddWithValue("@velocidad", pokemon.Velocidad);
            comando.Parameters.AddWithValue("@nivel", pokemon.Nivel);
        }

        static void Pausa()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
