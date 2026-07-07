void ejercicio1()
{
    int[][] numeros = new int[4][];
    numeros[0] = [1];
    numeros[1] = [2, 3];
    numeros[2] = [4, 5, 6];
    numeros[3] = [7, 8, 9, 10];
    for (int i = 0; i < numeros.Length; i++)
    {
        for (int j = 0; j < numeros[i].Length; j++)
        {
            Console.Write(numeros[i][j]);
        }
        Console.WriteLine();
    }


}
void ejercicio2()
{
    int[][] matrizIrregular = new int[][]
    {
    new int[] { 1, 2 },
    new int[] { 3, 4, 5, 6 },
    new int[] { 7, 8, 9 }
    };
    int acum = 0;
    for(int i = 0; i < matrizIrregular.Length; i++)
    {
        for (int j = 0; j < matrizIrregular[i].Length; j++)
        {
            acum++;
        }
    }
    Console.WriteLine("El tamaño total de la matriz irregular es de " + acum);


}

void ejercicio3()
{
    int[][] matrizIrregular = new int[][]
  {
    new int[] { 1, 2 },
    new int[] { 3, 4, 5, 6 },
    new int[] { 7, 8, 9 }
  };
    int acum1 = 0;
    int acum2 = 0;
    int acum3 = 0;
        for (int j = 0; j < matrizIrregular[0].Length; j++)
        {
        acum1++;
        }

    for (int j = 0; j < matrizIrregular[1].Length; j++)
    {
        acum2++;
    }
    for (int j = 0; j < matrizIrregular[2].Length; j++)
    {
        acum3++;
    }
    if (acum1 > acum2 && acum1 > acum3)
    {
        Console.WriteLine("El indice mas grande es el primero, con un total de: " + acum1);
    }
    if (acum2 > acum1 && acum2 > acum3)
    {
        Console.WriteLine("El indice mas grande es el segundo, con un total de: " + acum2);
    }
    if (acum3 > acum2 && acum3 > acum1)
    {
        Console.WriteLine("El indice mas grande es el tercero, con un total de: " + acum3);
    }


}

void ejercicio4()
{
    int[][] matrizIrregular = new int[][]
{
    new int[] { 1, 2 },
    new int[] { 3, 4, 5, 6 },
    new int[] { 7, 8, 9 }

};
    int[] acumulado = new int[3];
    for (int i = 0; i < matrizIrregular.Length; i++)
    {
        for (int j = 0; j < matrizIrregular[i].Length; j++)
        {

           acumulado[i] += matrizIrregular[i][j];


        }
    }

    for (int i = 0; i < acumulado.Length; i++)
    {
        Console.WriteLine(acumulado[i]);
    }


}

void ejercicio5()
{
    int[][] matrizIrregular = new int[][]
{
    new int[] { 1, 2 },
    new int[] { 3, 4, 5, 6 },
    new int[] { 7, 8, 9 }

};
    int acum = 0;
    int fila = 0;
    int columna = 0;
    for (int i = 0; i < matrizIrregular.Length; i++)
    {

        for (int j = 0; j < matrizIrregular[i].Length; j++)
        {
            if (acum < matrizIrregular[i][j])
            {
                acum = matrizIrregular[i][j];
                fila = i;
                columna = j;
            }
        }
    }
    Console.WriteLine("El valor mas alto de la matriz es de " + acum);
    Console.WriteLine("Se encuentra en la posicion " + fila + " " + columna);




}

void ejercicio6()
{
    int[][] matrizIrregular = new int[][]
{
    new int[] { 5, 10 },
    new int[] { 6, 7, 8, 2 },
    new int[] { 7, 8, 9 }

};
    double[] promedios = new double[3];
    for (int i = 0; i < matrizIrregular.Length; i++)
    {
        for (int j = 0; j < matrizIrregular[i].Length; j++)
        {
            promedios[i] += matrizIrregular[i][j];
        }
    }
    Console.WriteLine("El promedio de las notas del alumno 1 es: " + promedios[0] / 2.0);
    Console.WriteLine("El promedio de las notas del segundo alumno es: " + promedios[1] / 4.0);
    Console.WriteLine("El promedio de las notas del tercer alumno es: " + promedios[2] / 3.0);




}
int[][] matrizIrregular = new int[][]
{
    new int[] { 5, 10 },
    new int[] { 6, 7, 8, 2 },
    new int[] { 7, 8, 9 }

};
Console.WriteLine("Ingrese un numero");
int numeroingresado = int.Parse(Console.ReadLine());

if (encontrarnumero(matrizIrregular, numeroingresado))
{
    Console.WriteLine("Numero encontrado");
}
else
{
    Console.WriteLine("Numero NO encontrado (;");
}
    bool encontrarnumero(int[][] matriz, int numeroingresadoejemplo)
    {
        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz[i].Length; j++)
            {
                if (matriz[i][j] == numeroingresadoejemplo)
                {
                    return true;
                }
            }
        }
        return false;



    }
