namespace ConsoleApp6
using System;

internal class Program
{
    // 1. El Triángulo Rectángulo
    static void Triangulo()
    {
        int[][] matriz = new int[4][];

        int numero = 1;

        for (int i = 0; i < 4; i++)
        {
            matriz[i] = new int[i + 1];

            for (int j = 0; j < matriz[i].Length; j++)
            {
                matriz[i][j] = numero;
                numero++;
            }
        }

        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz[i].Length; j++)
            {
                Console.Write(matriz[i][j] + " ");
            }

            Console.WriteLine();
        }
    }

    // 2. Contar Elementos Totales
    static void ContarElementos()
    {
        int[][] matriz =
        {
            new int[] { 1, 2 },
            new int[] { 3, 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        int total = 0;

        for (int i = 0; i < matriz.Length; i++)
        {
            total += matriz[i].Length;
        }

        Console.WriteLine("Cantidad total de elementos: " + total);
    }

    // 3. La Fila Más Larga
    static void FilaMasLarga()
    {
        int[][] matriz =
        {
            new int[] { 1, 2 },
            new int[] { 3, 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        int indice = 0;
        int mayor = matriz[0].Length;

        for (int i = 1; i < matriz.Length; i++)
        {
            if (matriz[i].Length > mayor)
            {
                mayor = matriz[i].Length;
                indice = i;
            }
        }

        Console.WriteLine("Índice de la fila más larga: " + indice);
        Console.WriteLine("Cantidad de elementos: " + mayor);
    }

    // 4. Suma por Filas
    static void SumaPorFilas()
    {
        int[][] matriz =
        {
            new int[] { 1, 2 },
            new int[] { 3, 4, 5 },
            new int[] { 6, 7, 8, 9 }
        };

        int[] sumas = new int[matriz.Length];

        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz[i].Length; j++)
            {
                sumas[i] += matriz[i][j];
            }
        }

        Console.WriteLine("Sumas de cada fila:");

        for (int i = 0; i < sumas.Length; i++)
        {
            Console.WriteLine("Fila " + i + ": " + sumas[i]);
        }
    }

    // 5. El Valor Máximo
    static void ValorMaximo()
    {
        int[][] matriz =
        {
            new int[] { 1, 8, 3 },
            new int[] { 4, 15 },
            new int[] { 7, 2, 10, 6 }
        };

        int maximo = matriz[0][0];
        int fila = 0;
        int columna = 0;

        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz[i].Length; j++)
            {
                if (matriz[i][j] > maximo)
                {
                    maximo = matriz[i][j];
                    fila = i;
                    columna = j;
                }
            }
        }

        Console.WriteLine("Valor máximo: " + maximo);
        Console.WriteLine("Fila: " + fila);
        Console.WriteLine("Columna: " + columna);
    }

    // 6. Promedio Escolar
    static void PromedioEscolar()
    {
        int[][] notas =
        {
            new int[] { 8, 7, 9 },
            new int[] { 6, 8 },
            new int[] { 10, 9, 8, 7 }
        };

        for (int i = 0; i < notas.Length; i++)
        {
            int suma = 0;

            for (int j = 0; j < notas[i].Length; j++)
            {
                suma += notas[i][j];
            }

            double promedio = (double)suma / notas[i].Length;

            Console.WriteLine(
                "Alumno " + (i + 1) +
                " - Promedio: " + promedio.ToString("F2")
            );
        }
    }

    // 7. Buscar un Intruso
    static bool BuscarIntruso(int[][] matriz, int x)
    {
        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz[i].Length; j++)
            {
                if (matriz[i][j] == x)
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("===== EJERCICIO 1 =====");
        Triangulo();

        Console.WriteLine("\n===== EJERCICIO 2 =====");
        ContarElementos();

        Console.WriteLine("\n===== EJERCICIO 3 =====");
        FilaMasLarga();

        Console.WriteLine("\n===== EJERCICIO 4 =====");
        SumaPorFilas();

        Console.WriteLine("\n===== EJERCICIO 5 =====");
        ValorMaximo();

        Console.WriteLine("\n===== EJERCICIO 6 =====");
        PromedioEscolar();

        Console.WriteLine("\n===== EJERCICIO 7 =====");

        int[][] matriz =
        {
            new int[] { 1, 2 },
            new int[] { 3, 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        Console.Write("Ingrese el número que desea buscar: ");
        int x = int.Parse(Console.ReadLine());

        if (BuscarIntruso(matriz, x))
        {
            Console.WriteLine("El número existe dentro del arreglo.");
        }
        else
        {
            Console.WriteLine("El número no existe dentro del arreglo.");
        }

        Console.ReadKey();
    }
}
