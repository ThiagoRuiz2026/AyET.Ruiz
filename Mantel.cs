string[] cartas = new string[8];
string[] mazo =
{
"As", "2", "3", "4", "5", "6", "7", "8", "10", "J", "Q", "K"
};
Random random = new Random();

for (int i = 0; i < cartas.Length; i++)
{
    cartas[i] = mazo[random.Next(0, mazo.Length)];

}
int opcion = 0;
while (opcion != 3)
{
    Console.WriteLine("MENU");
    Console.WriteLine("1: Ver Cartas");
    Console.WriteLine("2: Descartar Cartas");
    Console.WriteLine("3: Salir");
    opcion = int.Parse(Console.ReadLine());
    if (opcion == 1)
    {
        Console.WriteLine("Tus Cartas");
        for (int i = 0; i < cartas.Length; i++)
        {
            Console.WriteLine(i + "-" + cartas[i]);
        }
    }
    else if (opcion == 2)
    {
        Console.WriteLine("¿Cuantas cartas queres descartar?");
        int cantidad = int.Parse(Console.ReadLine());
        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("ingrese la posicion de la carta a descartar");
            int posicion = int.Parse(Console.ReadLine());
            cartas[posicion] = mazo[random.Next(0, mazo.Length)];
        }
        Console.WriteLine("Cartas actualizadas");
        for (int i = 0; i < cartas.Length; i++)
        {
            Console.WriteLine(i + "-" + cartas[i]);
        }
    }
    else if (opcion == 3)
    {
        Console.WriteLine("juego terminado");
    }
    else
    {
        Console.WriteLine("Opcion Invalida");
    }
}
Console.ReadKey();

 