using System;

namespace EjercicioPokemon
{
    struct Pokemon
    {
        public int PS;
        public int Ataque;
        public int Defensa;
        public int AtaqueEspecial;
        public int DefensaEspecial;
        public int Velocidad;
        public string Estado;
    }

    struct Entrenador
    {
        public string Nombre;
        public int Pokedolares;
        public string[] Medallas;
        public Pokemon[] Pokemones;
    }

    class Program
    {
        static int NivelTotal(Entrenador entrenador)
        {
            int total = 0;

            foreach (Pokemon pokemon in entrenador.Pokemones)
            {
                total = total + pokemon.PS;
                total = total + pokemon.Ataque;
                total = total + pokemon.Defensa;
                total = total + pokemon.AtaqueEspecial;
                total = total + pokemon.DefensaEspecial;
                total = total + pokemon.Velocidad;
            }

            return total;
        }

        static void ComprarPocion(ref Entrenador entrenador)
        {
            if (entrenador.Pokedolares >= 200)
            {
                entrenador.Pokedolares = entrenador.Pokedolares - 200;
                Console.WriteLine("Pocion comprada correctamente.");
            }
            else
            {
                Console.WriteLine("No se pudo comprar");
            }
        }

        static Entrenador MayorMedallas(Entrenador entrenador1, Entrenador entrenador2)
        {
            if (entrenador1.Medallas.Length > entrenador2.Medallas.Length)
            {
                return entrenador1;
            }
            else
            {
                return entrenador2;
            }
        }

        static int CantidadAlterados(Entrenador entrenador)
        {
            int cantidad = 0;

            foreach (Pokemon pokemon in entrenador.Pokemones)
            {
                if (pokemon.Estado != "Normal")
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        static Entrenador MayorAlterados(Entrenador entrenador1, Entrenador entrenador2)
        {
            if (CantidadAlterados(entrenador1) > CantidadAlterados(entrenador2))
            {
                return entrenador1;
            }
            else
            {
                return entrenador2;
            }
        }

        static void Main(string[] args)
        {
            Entrenador entrenador1 = new Entrenador();
            Entrenador entrenador2 = new Entrenador();

            Console.WriteLine(" ENTRENADOR 1 ");

            Console.Write("Nombre: ");
            entrenador1.Nombre = Console.ReadLine();

            Console.Write("Pokedolares: ");
            entrenador1.Pokedolares = int.Parse(Console.ReadLine());

            Console.Write("Cantidad de medallas: ");
            int cantidadMedallas1 = int.Parse(Console.ReadLine());

            entrenador1.Medallas = new string[cantidadMedallas1];

            for (int i = 0; i < cantidadMedallas1; i++)
            {
                Console.Write("Medalla " + (i + 1) + ": ");
                entrenador1.Medallas[i] = Console.ReadLine();
            }

            Console.Write("Cantidad de Pokemones: ");
            int cantidadPokemones1 = int.Parse(Console.ReadLine());

            entrenador1.Pokemones = new Pokemon[cantidadPokemones1];

            for (int i = 0; i < cantidadPokemones1; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Pokemon " + (i + 1));

                Console.Write("PS: ");
                entrenador1.Pokemones[i].PS = int.Parse(Console.ReadLine());

                Console.Write("Ataque: ");
                entrenador1.Pokemones[i].Ataque = int.Parse(Console.ReadLine());

                Console.Write("Defensa: ");
                entrenador1.Pokemones[i].Defensa = int.Parse(Console.ReadLine());

                Console.Write("Ataque Especial: ");
                entrenador1.Pokemones[i].AtaqueEspecial = int.Parse(Console.ReadLine());

                Console.Write("Defensa Especial: ");
                entrenador1.Pokemones[i].DefensaEspecial = int.Parse(Console.ReadLine());

                Console.Write("Velocidad: ");
                entrenador1.Pokemones[i].Velocidad = int.Parse(Console.ReadLine());

                Console.Write("Estado: ");
                entrenador1.Pokemones[i].Estado = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine(" ENTRENADOR 2 ");

            Console.Write("Nombre: ");
            entrenador2.Nombre = Console.ReadLine();

            Console.Write("Pokedolares: ");
            entrenador2.Pokedolares = int.Parse(Console.ReadLine());

            Console.Write("Cantidad de medallas: ");
            int cantidadMedallas2 = int.Parse(Console.ReadLine());

            entrenador2.Medallas = new string[cantidadMedallas2];

            for (int i = 0; i < cantidadMedallas2; i++)
            {
                Console.Write("Medalla " + (i + 1) + ": ");
                entrenador2.Medallas[i] = Console.ReadLine();
            }

            Console.Write("Cantidad de Pokemones: ");
            int cantidadPokemones2 = int.Parse(Console.ReadLine());

            entrenador2.Pokemones = new Pokemon[cantidadPokemones2];

            for (int i = 0; i < cantidadPokemones2; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Pokemon " + (i + 1));

                Console.Write("PS: ");
                entrenador2.Pokemones[i].PS = int.Parse(Console.ReadLine());

                Console.Write("Ataque: ");
                entrenador2.Pokemones[i].Ataque = int.Parse(Console.ReadLine());

                Console.Write("Defensa: ");
                entrenador2.Pokemones[i].Defensa = int.Parse(Console.ReadLine());

                Console.Write("Ataque Especial: ");
                entrenador2.Pokemones[i].AtaqueEspecial = int.Parse(Console.ReadLine());

                Console.Write("Defensa Especial: ");
                entrenador2.Pokemones[i].DefensaEspecial = int.Parse(Console.ReadLine());

                Console.Write("Velocidad: ");
                entrenador2.Pokemones[i].Velocidad = int.Parse(Console.ReadLine());

                Console.Write("Estado: ");
                entrenador2.Pokemones[i].Estado = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine(" RESULTADOS ");

            int nivel1 = NivelTotal(entrenador1);
            int nivel2 = NivelTotal(entrenador2);

            if (nivel1 > nivel2)
            {
                Console.WriteLine("Entrenador con mayor nivel: " + entrenador1.Nombre);
            }
            else if (nivel2 > nivel1)
            {
                Console.WriteLine("Entrenador con mayor nivel: " + entrenador2.Nombre);
            }
            else
            {
                Console.WriteLine("Ambos entrenadores tienen el mismo nivel.");
            }

            Entrenador ganadorMedallas = MayorMedallas(entrenador1, entrenador2);
            Console.WriteLine("Entrenador con mas medallas: " + ganadorMedallas.Nombre);

            Entrenador ganadorAlterados = MayorAlterados(entrenador1, entrenador2);
            Console.WriteLine("Entrenador con mas Pokemones alterados: " + ganadorAlterados.Nombre);

            Console.WriteLine();
            Console.WriteLine("COMPRA DE POCION ");

            Console.WriteLine("Pokedolares de " + entrenador1.Nombre + ": " + entrenador1.Pokedolares);

            ComprarPocion(ref entrenador1);

            Console.WriteLine("Pokedolares restantes: " + entrenador1.Pokedolares);

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}



