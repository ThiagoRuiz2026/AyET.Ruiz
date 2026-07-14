using System;

namespace ConsoleApp1
{
    struct Personaje
    {
        public string nombre;
        public int poder;
        public string[] items;
        public int cantidadItems;
    }

    struct Sala
    {
        public int dificultad;
        public string item;
        public int poderItem;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            string[] listaItems = { "Armadura", "Arma", "Poción", "Amuleto" };

            Personaje p1 = new Personaje();
            p1.nombre = "Jugador 1";
            p1.poder = 50;
            p1.items = new string[20];
            p1.cantidadItems = 0;

            Personaje p2 = new Personaje();
            p2.nombre = "Jugador 2";
            p2.poder = 50;
            p2.items = new string[20];
            p2.cantidadItems = 0;

            for (int turno = 1; turno <= 20; turno++)
            {
                Console.WriteLine("TURNO " + turno + " ");

                Sala sala = new Sala();
                sala.dificultad = r.Next(20, 81);
                sala.item = listaItems[r.Next(4)];
                sala.poderItem = r.Next(5, 16);

                Console.WriteLine("Sala del Jugador 1");
                Console.WriteLine("Dificultad: " + sala.dificultad);

                if (p1.poder > sala.dificultad)
                {
                    p1.items[p1.cantidadItems] = sala.item;
                    p1.cantidadItems++;
                    p1.poder += sala.poderItem;

                    Console.WriteLine("Robó: " + sala.item);
                    Console.WriteLine("Poder actual: " + p1.poder);
                }
                else
                {
                    Console.WriteLine("No pudo robar el item.");
                }

                sala.dificultad = r.Next(20, 81);
                sala.item = listaItems[r.Next(4)];
                sala.poderItem = r.Next(5, 16);

                Console.WriteLine("Sala del Jugador 2");
                Console.WriteLine("Dificultad: " + sala.dificultad);

                if (p2.poder > sala.dificultad)
                {
                    p2.items[p2.cantidadItems] = sala.item;
                    p2.cantidadItems++;
                    p2.poder += sala.poderItem;

                    Console.WriteLine("Robó: " + sala.item);
                    Console.WriteLine("Poder actual: " + p2.poder);
                }
                else
                {
                    Console.WriteLine("No pudo robar el item.");
                }

                Console.WriteLine();
            }

            Console.WriteLine("PELEA FINAL");

            if (p1.poder > p2.poder)
            {
                Console.WriteLine("Ganador: " + p1.nombre);
                Console.WriteLine("Poder: " + p1.poder);
                Console.WriteLine("Items:");

                for (int i = 0; i < p1.cantidadItems; i++)
                {
                    Console.WriteLine(p1.items[i]);
                }
            }
            else if (p2.poder > p1.poder)
            {
                Console.WriteLine("Ganador: " + p2.nombre);
                Console.WriteLine("Poder: " + p2.poder);
                Console.WriteLine("Items:");

                for (int i = 0; i < p2.cantidadItems; i++)
                {
                    Console.WriteLine(p2.items[i]);
                }
            }
            else
            {
                Console.WriteLine("Empate.");
            }

            Console.ReadKey();
        }
    }
}
