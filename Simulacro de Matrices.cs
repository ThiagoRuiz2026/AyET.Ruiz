string[,] equipo1 = new string[23, 3];
string[,] equipo2 = new string[23, 3];

string[] nombres =
{
    "Messi","CR7","Dibu","LaCobra","Pele",
    "Maradona","Fernandez","Paredes","Ronaldo","Mbape",
    "Donato","Camargo","Maciel","Macri","Mirtha Legrand"
};

string[] posiciones =
{
    "Delantero",
    "Mediocampista",
    "Defensor",
    "Arquero"
};

Random random = new Random();

int total1 = 0;
int total2 = 0;


for (int i = 0; i < 23; i++)
{
    equipo1[i, 0] = nombres[random.Next(nombres.Length)];

    int valoracion = random.Next(50, 101);

    equipo1[i, 1] = valoracion.ToString();

    equipo1[i, 2] = posiciones[random.Next(posiciones.Length)];

    total1 += valoracion;
}
for (int i = 0; i < 23; i++)
{
    equipo2[i, 0] = nombres[random.Next(nombres.Length)];

    int valoracion = random.Next(50, 101);

    equipo2[i, 1] = valoracion.ToString();

    equipo2[i, 2] = posiciones[random.Next(posiciones.Length)];

    total2 += valoracion;
}
//equipo 1
Console.WriteLine("EQUIPO 1");
Console.WriteLine();

for (int i = 0; i < 23; i++)
{
    Console.WriteLine(
        equipo1[i, 0] + " - " +
        equipo1[i, 1] + " - " +
        equipo1[i, 2]);
}

Console.WriteLine();
Console.WriteLine("Valoracion total: " + total1);
// equipo 2
Console.WriteLine();
Console.WriteLine("EQUIPO 2");
Console.WriteLine();

for (int i = 0; i < 23; i++)
{
    Console.WriteLine(
        equipo2[i, 0] + " - " +
        equipo2[i, 1] + " - " +
        equipo2[i, 2]);
}

Console.WriteLine();
Console.WriteLine("Valoracion total: " + total2);
Console.WriteLine();

if (total1 > total2)
{
    Console.WriteLine("El equipo 1 tiene mas chances de ganar");
}
else if (total2 > total1)
{
    Console.WriteLine("El equipo 2 tiene mas chances de ganar");
}
else
{
    Console.WriteLine("Los equipos tienen las mismas chances");
}

//parte2
Console.WriteLine();
Console.WriteLine("POTENCIA RECURSIVA");
Console.WriteLine();

int Potencia(int numero, int exponente)
{
    if (exponente == 0)
    {
        return 1;
    }

    return numero * Potencia(numero, exponente - 1);
}

Console.Write("Ingrese un numero: ");
int numero = int.Parse(Console.ReadLine());

Console.Write("Ingrese un exponente: ");
int exponente = int.Parse(Console.ReadLine());

int resultado = Potencia(numero, exponente);

Console.WriteLine("Resultado: " + resultado);

