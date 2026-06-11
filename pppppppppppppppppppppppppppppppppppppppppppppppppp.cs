char[,] tablero =
{
    {' ',' ',' '},
    {' ',' ',' '},
    {' ',' ',' '}
};

char jugador = 'X';
bool ganador = false;
int movimientos = 0;

while (!ganador && movimientos < 9)
{
    Console.Clear();

    Console.WriteLine("  0 1 2");

    for (int i = 0; i < 3; i++)
    {
        Console.Write(i + " ");

        for (int j = 0; j < 3; j++)
        {
            Console.Write(tablero[i, j]);

            if (j < 2)
            {
                Console.Write("|");
            }
        }

        Console.WriteLine();

        if (i < 2)
        {
            Console.WriteLine("-----");
        }
    }

    Console.WriteLine();
    Console.WriteLine("Inicia " + jugador);

    Console.Write("Fila: ");
    int fila = int.Parse(Console.ReadLine());

    Console.Write("Columna: ");
    int columna = int.Parse(Console.ReadLine());

    if (tablero[fila, columna] != ' ')
    {
        Console.WriteLine("Casilla ocupada");
        Console.ReadKey();
        continue;
    }

    tablero[fila, columna] = jugador;
    movimientos++;

    for (int i = 0; i < 3; i++)
    {
        if (tablero[i, 0] == jugador &&
            tablero[i, 1] == jugador &&
            tablero[i, 2] == jugador)
        {
            ganador = true;
        }
    }

    for (int j = 0; j < 3; j++)
    {
        if (tablero[0, j] == jugador &&
            tablero[1, j] == jugador &&
            tablero[2, j] == jugador)
        {
            ganador = true;
        }
    }

    if (tablero[0, 0] == jugador &&
        tablero[1, 1] == jugador &&
        tablero[2, 2] == jugador)
    {
        ganador = true;
    }

    if (tablero[0, 2] == jugador &&
        tablero[1, 1] == jugador &&
        tablero[2, 0] == jugador)
    {
        ganador = true;
    }

    if (ganador)
    {
        break;
    }

    if (jugador == 'X')
    {
        jugador = 'O';
    }
    else
    {
        jugador = 'X';
    }
}

Console.Clear();

Console.WriteLine("  0 1 2");

for (int i = 0; i < 3; i++)
{
    Console.Write(i + " ");

    for (int j = 0; j < 3; j++)
    {
        Console.Write(tablero[i, j]);

        if (j < 2)
        {
            Console.Write("|");
        }
    }

    Console.WriteLine();

    if (i < 2)
    {
        Console.WriteLine("-----");
    }
}

Console.WriteLine();

if (ganador)
{
    Console.WriteLine("Gano " + jugador);
}
else
{
    Console.WriteLine("Empate");
}

