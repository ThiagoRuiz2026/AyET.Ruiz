using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public struct Persona
    {
        public int VidaTotal { get; set; }
        public int VidaActual { get; set; }
        public string UltimaAccion { get; set; }

        public Persona(int vidaTotal, int vidaActual, string ultimaAccion)
        {
            VidaTotal = vidaTotal;
            VidaActual = vidaActual;
            UltimaAccion = ultimaAccion;
        }
    }

    internal class Program
    {
        static void VolverEnElTiempo(Stack<Persona> historialDelPersonaje)
        {
            if (historialDelPersonaje.Count > 0)
            {
                Persona accionBorrada = historialDelPersonaje.Pop();

                Console.WriteLine("\nAcción borrada:");
                Console.WriteLine(accionBorrada.UltimaAccion);
            }
        }

        static void Golpear(Stack<Persona> historialDelPersonaje)
        {
            if (historialDelPersonaje.Count > 0)
            {
                Persona personaje = historialDelPersonaje.Peek();

                personaje.VidaActual = personaje.VidaActual - 20;
                personaje.UltimaAccion = "Golpe recibido";

                historialDelPersonaje.Push(personaje);

                Console.WriteLine("\nSe agregó una nueva acción:");
                Console.WriteLine(personaje.UltimaAccion);
            }
        }

        static void Main(string[] args)
        {
            Stack<Persona> historialDelPersonaje = new Stack<Persona>();

            Persona personaje1 = new Persona(100, 100, "El personaje apareció");
            Persona personaje2 = new Persona(100, 90, "El personaje recibió daño");
            Persona personaje3 = new Persona(100, 80, "El personaje perdió más vida");

            historialDelPersonaje.Push(personaje1);
            historialDelPersonaje.Push(personaje2);
            historialDelPersonaje.Push(personaje3);

            Console.WriteLine("HISTORIAL DEL PERSONAJE:");

            foreach (Persona personaje in historialDelPersonaje)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Vida total: " + personaje.VidaTotal);
                Console.WriteLine("Vida actual: " + personaje.VidaActual);
                Console.WriteLine("Última acción: " + personaje.UltimaAccion);
            }

            VolverEnElTiempo(historialDelPersonaje);
            Golpear(historialDelPersonaje);

            Console.ReadKey();
        }
    }
}

