using System;
using System.Collections.Generic;

namespace SimulacroEvaluaciónstructsystacks
{
    internal class Program
    {
        public struct Ubicacion
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string NombreZona { get; set; }
               
            public Ubicacion(int x, int y, string nombreZona)
            {
                X = x;
                Y = y;
                NombreZona = nombreZona;
            }

            public void MostrarUbicacion()
            {
                Console.WriteLine(
                    $"Zona: {NombreZona} | Coordenadas: X = {X}, Y = {Y}"
                );
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("   HISTORIAL DE UBICACIONES");
            Console.WriteLine("");
            Console.WriteLine();

            Stack<Ubicacion> historialUbicaciones =
                new Stack<Ubicacion>();

            Ubicacion ubicacion1 =
                new Ubicacion(10, 20, "Bosque");

            Ubicacion ubicacion2 =
                new Ubicacion(35, 15, "Cueva");

            Ubicacion ubicacion3 =
                new Ubicacion(50, 40, "Castillo");

            historialUbicaciones.Push(ubicacion1);
            historialUbicaciones.Push(ubicacion2);
            historialUbicaciones.Push(ubicacion3);

            Console.WriteLine("Ubicaciones almacenadas en el historial:");
            Console.WriteLine();

            foreach (Ubicacion ubicacion in historialUbicaciones)
            {
                ubicacion.MostrarUbicacion();
            }

            Console.WriteLine();
            Console.WriteLine("");
            Console.WriteLine("El jugador retrocede un paso...");
            Console.WriteLine("");
            Console.WriteLine();

            if (historialUbicaciones.Count > 0)
            {
                Ubicacion ubicacionRemovida =
                    historialUbicaciones.Pop();

                Console.WriteLine("Ubicación removida:");

                ubicacionRemovida.MostrarUbicacion();
            }

            Console.WriteLine();
            Console.WriteLine("");

            if (historialUbicaciones.Count > 0)
            {
                Ubicacion ubicacionActual =
                    historialUbicaciones.Peek();

                Console.WriteLine("Ubicación que queda en la cima:");

                ubicacionActual.MostrarUbicacion();
            }
            else
            {
                Console.WriteLine(
                    "No quedan ubicaciones en el historial."
                );
            }

            Console.WriteLine("");
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
