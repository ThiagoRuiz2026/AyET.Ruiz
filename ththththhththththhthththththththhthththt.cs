using System;

namespace ConsoleApp3
{
    internal class Program
    {
        public struct Punto2D
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

        public struct Dimensiones
        {
            public int Ancho { get; set; }
            public int Alto { get; set; }
        }

        public struct Producto
        {
            public string Nombre { get; set; }
            public int Codigo { get; set; }
            public double Precio { get; set; }
        }

        public struct Estudiante
        {
            public string Nombre { get; set; }
            public double[] Notas { get; set; }

            public double CalcularPromedio()
            {
                double suma = 0;

                foreach (double nota in Notas)
                {
                    suma += nota;
                }

                return suma / Notas.Length;
            }
        }

        static void Main(string[] args)
        {
            // Ejercicio 1
            Punto2D punto = new Punto2D(5, 10);
            punto.Mostrar();

            Console.WriteLine();

            // Ejercicio 2
            Dimensiones d1 = new Dimensiones();
            d1.Ancho = 10;
            d1.Alto = 20;

            Dimensiones d2 = d1;
            d2.Ancho = 99;

            Console.WriteLine($"d1: {d1.Ancho}, {d1.Alto}");
            Console.WriteLine($"d2: {d2.Ancho}, {d2.Alto}");

           

            Console.WriteLine();

            // Ejercicio 3
            Producto[] productos = new Producto[3];

            productos[0].Nombre = "Mouse";
            productos[0].Codigo = 1;
            productos[0].Precio = 15000;

            productos[1].Nombre = "Teclado";
            productos[1].Codigo = 2;
            productos[1].Precio = 25000;

            productos[2].Nombre = "Monitor";
            productos[2].Codigo = 3;
            productos[2].Precio = 180000;

            foreach (Producto p in productos)
            {
                Console.WriteLine($"{p.Nombre} - ${p.Precio}");
            }

            Console.WriteLine();

            // Ejercicio 4
            Estudiante e = new Estudiante();
            e.Nombre = "Thiago";
            e.Notas = new double[] { 8.5, 9.0, 7.5 };

            Console.WriteLine($"{e.Nombre} - Promedio: {e.CalcularPromedio()}");
        }
    }
}
