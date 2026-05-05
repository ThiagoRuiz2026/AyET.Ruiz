Console.WriteLine("Ingrese 0 o 1:");

int num;

while (!int.TryParse(Console.ReadLine(), out num) || (num != 0 && num != 1))
{
    Console.WriteLine("Error. Ingrese 0 o 1:");
}


// ----------------------------

Console.WriteLine("Ingrese un número de 2 cifras:");

int num2;

while (!int.TryParse(Console.ReadLine(), out num2) || num2 < 10 || num2 > 99)
{
    Console.WriteLine("Error. Ingrese un número de 2 cifras:");
}

