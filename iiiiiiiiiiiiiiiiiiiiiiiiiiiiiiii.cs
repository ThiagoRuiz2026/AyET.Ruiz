
//1
Console.WriteLine("Ejercicio 1");
int[,] M =
{
    {1, 2, 3 },
    {4, 5, 6 },
    {7, 8, 9 }
};
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(M[i, j] + "-");
    }
    Console.WriteLine("");
}
//2
Console.WriteLine("Ejercicio2");
int[,] M2 =
{
    {10, 20, 30 },
    {40, 50, 60 },
    {70, 80, 90 }
};
int suma = 0;
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        suma += M2[i, j];
    }
}

Console.WriteLine("Suma total: " + suma);

//3
Console.WriteLine("Ejercico3");
int[,] M3 =
{
{1, 2, 3, 4 },
{5, 6, 7, 8 },
{9, 10, 11, 12 },
{13, 14, 15, 16 },
};
Console.Write("Filan (0-3): ");
int fila =
    int.Parse(Console.ReadLine());
Console.Write("Columna (0=3)");
int columna =
int.Parse(Console.ReadLine());
Console.WriteLine("Elementos: " + M3[fila, columna]);
//4
Console.WriteLine("Ejercicio4");
int mayor= M3 [0, 0];
for (int i = 0; i < 4; i++)
{
    int sumaFila = 0;
    for (int j = 0; j < 4; j++)
    {
        sumaFila += M3[i, j];
    }
}
Console.WriteLine("Mayor: " + mayor);

//5
Console.WriteLine("Ejercicio5");
for (int i = 0; i < 4; i++)
{
    int sumaFila = 0;
    for (int j = 0; j < 4; j++)
    {
        sumaFila += M3[i, j];
    }
    Console.WriteLine(" Suma fila " + i + ": " + sumaFila);

}
for (int j = 0; j < 4; j++)
{
    int sumaColumna = 0;
    for (int i = 0; i < 4; i++)
    {
        sumaColumna += M3[i, j];
    }
    Console.WriteLine("suma columna " + j + ": " + sumaColumna);
}
//6
Console.WriteLine("Ejercicio6");
int[,] transpuesta = new int[4, 4];
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        transpuesta[j, i] = M3[i, j];
    }
}
Console.WriteLine("Matriz transpuesta");
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write(transpuesta[i, j] + "-");

    }
    Console.WriteLine("");
}
//7

Console.WriteLine("Ejercicio7");
int[,] M7 =
{
    {1, 2, 3, 4 },
    {8, 5, 9, 2 },
    {4, 5, 6, 7 }
};Console.Write("Nuero a buscar: ");
int buscar = int.Parse(Console.ReadLine());
int cantidad = 0;
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        if (M7[i, j] == buscar)
        {
            cantidad++;
        }
    }
}
Console.WriteLine("aparecer " + cantidad + "veces");
//8
Console.WriteLine("Ejercicio8");
int[,] M8 =
{
    {5, 10, 15, 20 },
    {25, 30, 35, 40 },
    {45, 50, 55, 60 },
    {65, 70, 75, 80 }
};
int total = 0;
    for (int i = 0; i < 4; i++)
{
    for (int j =0; j<4; j++)
    {
        total += M8[i, j]; 
    }
}
double promedio = (double)total / 16;

Console.WriteLine("Promedio: " + promedio);
int[,] nueva = new int[4, 4];
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        if (M8[i, j] < promedio)
        {
            nueva[i, j] = (int)promedio;
        }
        else
        {
            nueva[i, j] = M8[i, j];
        }
    }
}
Console.WriteLine("nueva matriz: ");
for (int i= 0; i <4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write(nueva[i, j] + "-");
    }
    Console.WriteLine("");
}

