using System;

internal class Program
{
    // Vector original
    static int[] vectorOriginal =
    {
        37, 12, 45, 3, 28, 19, 50, 7, 31, 16,
        42, 9, 25, 1, 34, 21, 48, 14, 5, 39,
        27, 11, 44, 8, 33, 18, 29, 2, 46, 23,
        15, 41, 6, 35, 20, 49, 10, 32, 24, 4,
        38, 17, 30, 13, 47, 22, 36, 26, 43, 40
    };

    // Copiar vector
    static int[] CopiarVector(int[] vector)
    {
        int[] copia = new int[vector.Length];

        for (int i = 0; i < vector.Length; i++)
        {
            copia[i] = vector[i];
        }

        return copia;
    }

    // Mostrar vector
    static void MostrarVector(int[] vector)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            Console.Write(vector[i] + " ");
        }

        Console.WriteLine();
    }

    // Búsqueda secuencial simple
    static int BusquedaSecuencialSimple(int[] vector, int buscado)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            if (vector[i] == buscado)
            {
                return i;
            }
        }

        return -1;
    }

    // Búsqueda secuencial optimizada
    static int BusquedaSecuencialOptimizada(int[] vector, int buscado)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            if (vector[i] == buscado)
            {
                return i;
            }

            if (vector[i] > buscado)
            {
                return -1;
            }
        }

        return -1;
    }

    // Búsqueda binaria iterativa
    static int BusquedaBinariaIterativa(int[] vector, int buscado)
    {
        int inicio = 0;
        int fin = vector.Length - 1;

        while (inicio <= fin)
        {
            int medio = (inicio + fin) / 2;

            if (vector[medio] == buscado)
            {
                return medio;
            }

            if (buscado < vector[medio])
            {
                fin = medio - 1;
            }
            else
            {
                inicio = medio + 1;
            }
        }

        return -1;
    }

    // Búsqueda binaria recursiva
    static int BusquedaBinariaRecursiva(
        int[] vector,
        int buscado,
        int inicio,
        int fin)
    {
        if (inicio > fin)
        {
            return -1;
        }

        int medio = (inicio + fin) / 2;

        if (vector[medio] == buscado)
        {
            return medio;
        }

        if (buscado < vector[medio])
        {
            return BusquedaBinariaRecursiva(
                vector,
                buscado,
                inicio,
                medio - 1);
        }
        else
        {
            return BusquedaBinariaRecursiva(
                vector,
                buscado,
                medio + 1,
                fin);
        }
    }

    // Burbuja clásico
    static void BurbujaClasico(int[] vector)
    {
        int[] copia = CopiarVector(vector);

        for (int i = 0; i < copia.Length - 1; i++)
        {
            for (int j = 0; j < copia.Length - 1; j++)
            {
                if (copia[j] > copia[j + 1])
                {
                    int aux = copia[j];
                    copia[j] = copia[j + 1];
                    copia[j + 1] = aux;
                }
            }
        }

        MostrarVector(copia);
    }

    // Burbuja optimizado
    static void BurbujaOptimizado(int[] vector)
    {
        int[] copia = CopiarVector(vector);

        bool intercambio = true;
        int limite = copia.Length - 1;

        while (intercambio)
        {
            intercambio = false;

            for (int j = 0; j < limite; j++)
            {
                if (copia[j] > copia[j + 1])
                {
                    int aux = copia[j];
                    copia[j] = copia[j + 1];
                    copia[j + 1] = aux;

                    intercambio = true;
                }
            }

            limite--;
        }

        MostrarVector(copia);
    }

    // Selección
    static void Seleccion(int[] vector)
    {
        int[] copia = CopiarVector(vector);

        for (int i = 0; i < copia.Length - 1; i++)
        {
            int posicionMenor = i;

            for (int j = i + 1; j < copia.Length; j++)
            {
                if (copia[j] < copia[posicionMenor])
                {
                    posicionMenor = j;
                }
            }

            int aux = copia[i];
            copia[i] = copia[posicionMenor];
            copia[posicionMenor] = aux;
        }

        MostrarVector(copia);
    }

    // Inserción
    static void Insercion(int[] vector)
    {
        int[] copia = CopiarVector(vector);

        for (int i = 1; i < copia.Length; i++)
        {
            int actual = copia[i];
            int j = i - 1;

            while (j >= 0 && copia[j] > actual)
            {
                copia[j + 1] = copia[j];
                j--;
            }

            copia[j + 1] = actual;
        }

        MostrarVector(copia);
    }

    // QuickSort
    static void QuickSort(int[] vector)
    {
        int[] copia = CopiarVector(vector);

        QuickSortRecursivo(copia, 0, copia.Length - 1);

        MostrarVector(copia);
    }

    // Parte recursiva de QuickSort
    static void QuickSortRecursivo(int[] vector, int inicio, int fin)
    {
        if (inicio >= fin)
        {
            return;
        }

        int pivote = vector[fin];
        int posicion = inicio;

        for (int i = inicio; i < fin; i++)
        {
            if (vector[i] < pivote)
            {
                int aux = vector[i];
                vector[i] = vector[posicion];
                vector[posicion] = aux;

                posicion++;
            }
        }

        int aux2 = vector[posicion];
        vector[posicion] = vector[fin];
        vector[fin] = aux2;

        QuickSortRecursivo(vector, inicio, posicion - 1);
        QuickSortRecursivo(vector, posicion + 1, fin);
    }

    // Stalin Sort
    static void StalinSort(int[] vector)
    {
        int[] copia = CopiarVector(vector);

        int[] resultado = new int[copia.Length];

        int cantidad = 0;

        resultado[cantidad] = copia[0];
        cantidad++;

        for (int i = 1; i < copia.Length; i++)
        {
            if (copia[i] >= resultado[cantidad - 1])
            {
                resultado[cantidad] = copia[i];
                cantidad++;
            }
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write(resultado[i] + " ");
        }

        Console.WriteLine();
    }

    // Bogo Sort
    static void BogoSort(int[] vector)
    {
        int[] copia = CopiarVector(vector);

        Random random = new Random();

        while (!EstaOrdenado(copia))
        {
            for (int i = 0; i < copia.Length; i++)
            {
                int posicionAleatoria = random.Next(copia.Length);

                int aux = copia[i];
                copia[i] = copia[posicionAleatoria];
                copia[posicionAleatoria] = aux;
            }
        }

        MostrarVector(copia);
    }

    // Comprobar si está ordenado
    static bool EstaOrdenado(int[] vector)
    {
        for (int i = 0; i < vector.Length - 1; i++)
        {
            if (vector[i] > vector[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    static void Main(string[] args)
    {
        // Mostrar vector original
        Console.WriteLine("VECTOR ORIGINAL:");
        MostrarVector(vectorOriginal);

        // Buscar elemento
        Console.Write("\nIngrese el elemento que desea buscar: ");
        int buscado = int.Parse(Console.ReadLine());

        // Búsquedas
        Console.WriteLine("\nBÚSQUEDAS:");

        int posicionSimple =
            BusquedaSecuencialSimple(vectorOriginal, buscado);

        Console.WriteLine(
            "Secuencial simple: " + posicionSimple);

        // Ordenar para las búsquedas que lo necesitan
        int[] vectorOrdenado = CopiarVector(vectorOriginal);

        QuickSortRecursivo(
            vectorOrdenado,
            0,
            vectorOrdenado.Length - 1);

        int posicionOptimizada =
            BusquedaSecuencialOptimizada(
                vectorOrdenado,
                buscado);

        Console.WriteLine(
            "Secuencial optimizada: " + posicionOptimizada);

        int posicionBinaria =
            BusquedaBinariaIterativa(
                vectorOrdenado,
                buscado);

        Console.WriteLine(
            "Binaria iterativa: " + posicionBinaria);

        int posicionBinariaRecursiva =
            BusquedaBinariaRecursiva(
                vectorOrdenado,
                buscado,
                0,
                vectorOrdenado.Length - 1);

        Console.WriteLine(
            "Binaria recursiva: " + posicionBinariaRecursiva);

        // Ordenamientos
        Console.WriteLine("\nORDENAMIENTOS:");

        Console.WriteLine("\nBurbuja clásico:");
        BurbujaClasico(vectorOriginal);

        Console.WriteLine("\nBurbuja optimizado:");
        BurbujaOptimizado(vectorOriginal);

        Console.WriteLine("\nSelección:");
        Seleccion(vectorOriginal);

        Console.WriteLine("\nInserción:");
        Insercion(vectorOriginal);

        Console.WriteLine("\nQuickSort:");
        QuickSort(vectorOriginal);

        Console.WriteLine("\nStalin Sort:");
        StalinSort(vectorOriginal);

        Console.WriteLine("\nBogo Sort:");
        BogoSort(vectorOriginal);

        // Respuestas
        Console.WriteLine("\nRESPUESTAS:");

        Console.WriteLine(
            "\nBúsqueda más eficiente: Binaria, O(log n), " +
            "si el vector está ordenado.");

        Console.WriteLine(
            "\nOrdenamiento más eficiente: QuickSort, " +
            "O(n log n) en promedio.");

        Console.WriteLine(
            "\nComplejidad algorítmica: es la forma de medir " +
            "cuántos recursos necesita un algoritmo según " +
            "la cantidad de datos.");

        Console.ReadKey();
    }
}
