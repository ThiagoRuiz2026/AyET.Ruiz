// ejercicio 1
Console.WriteLine("Ejercicio1");
int[,] M1 =
{
    {1,2,3,4},
    {5,6,7,8 },
    {9,10,11,12, },
    {13,14,15,16 }
};
int SumaEsquina =
    M1[0, 0] +
    M1[0, 3] +
    M1[3, 0] +
    M1[3, 3];
Console.WriteLine("Sumas de las esquinas: " + SumaEsquina);
Console.WriteLine();

//2 ejercicio2

Console.WriteLine("Ejercicio2");
int[,] M2 =
{
    {1,2,3, },
    {4,5,6 },
    {7,8,9 }
};
int SumaDiagonal1 = 0;
int SumaDiagonal2 = 0;

for (int i = 0; i < 3; i++)
{
    SumaDiagonal1 += M2[i, i];
    SumaDiagonal2 += M2[i, 2 - i];
}
Console.WriteLine("Suma diagonal principal: " + SumaDiagonal1);
Console.WriteLine("Suma diagonal secunadario: " + SumaDiagonal2);
Console.WriteLine();

//Ejercicio3

Console.WriteLine("Ejercicio3");
Console.WriteLine("Ingrese el tamaño de la matriz");
int n = int.Parse(Console.ReadLine());
int[,] Identidad = new int[n, n];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (i == j)
        {
            Identidad[i, j] = 1;
        }
        else
        {
            Identidad[i, j] = 1;
        }
    }
}
Console.WriteLine("Matriz Identidad: ");
for(int i= 0; i<0; i++)
{
    for (int j = 0; j < 0; j++)
    {
        Console.Write(Identidad[i, j] + "-");
    }
    Console.WriteLine(""); 
}

