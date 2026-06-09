int[,] mapa = new int[10, 10];
char[,] tablero = new char[10, 10];

Random random = new Random();

for (int i =0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        tablero[i, j] = '?';
    }
}

int tesorosColocados = 0;
while (tesorosColocados < 3)
{
    int fila = random.Next(10);
    int columna = random.Next(10);
    if (mapa[fila, columna] == 0)
    {
        mapa[fila, columna] = 1;
        tesorosColocados++;
    }
}
int intentos = 5;
int tesorosEncontrados = 0;

while (intentos > 0 && tesorosEncontrados < 3)
{
    Console.Clear();
    Console.WriteLine("Buscador de tesoros");
    Console.WriteLine("Tesoroso encontrados " + tesorosEncontrados);
    Console.WriteLine("Intentos restantes " + intentos);
    Console.WriteLine("");

    for (int i = 0; i < 10; i++)
    {
        for(int j =0; j <10; j++)
        {
            Console.Write(tablero[i, j] + "-");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.Write("ingrese fila (0-9): ");
    int fila = int.Parse(Console.ReadLine());
    Console.Write("ingrese columna (0-9): ");
    int columna = int.Parse(Console.ReadLine());
    if (mapa[fila, columna] == 1)
    {
        Console.WriteLine("Tesoro encontrado");
        mapa[fila, columna] = 2;
        tablero[fila, columna] = 'T';
        tesorosEncontrados++;
        intentos = 5;
    }
    else
    {
        Console.WriteLine("No hay tesoro");

        tablero[fila, columna] = 'x';
        intentos--;
    }
    Console.WriteLine("preciona una tecla para continuar ");
    Console.ReadKey();
}
Console.Clear();
if (tesorosEncontrados == 3)
{
    Console.WriteLine("FELICIDADES");
    Console.WriteLine("Encontramos los 3 tesoros");
}
else
{
    Console.WriteLine("GAMER OVER");
    Console.WriteLine("Te quedaste sin intentos");
}
Console.WriteLine();
Console.WriteLine("Ubicacion de los tesoros");
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        if (mapa[i, j] == 2)
        {
            Console.Write("T");
        }
        else
        {
             if (mapa[i, j] == 1)
            {
                Console.Write("T");
            }
            else
            {
                Console.Write("-");
            }
        }
    }

    Console.WriteLine();
}