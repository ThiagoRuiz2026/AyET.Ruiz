// Ejercicio N°1
Console.WriteLine("Inserte un numero, luego se determinará si es primo o no:");
int numero;
numero = Convert.ToInt32(Console.ReadLine());

bool esPrimo = true;

if (numero <= 1)
{
    esPrimo = false;
}

if (numero == 2)
{
    esPrimo = true;
}

if (numero % 2 == 0)
{
    esPrimo = false;
}

for (int x = 3; x < numero; x++)
{
    if (numero % x == 0)
    {
        esPrimo = false;
        break;
    }
}

if (esPrimo)
{
    Console.WriteLine("El número es primo");
}
else
{
    Console.WriteLine("El número no es primo");
}


//Ejercicio N°2
Console.WriteLine("");
Console.WriteLine("Ingrese un número, luego determinaremos su factorial");
int numero2;
numero2 = Convert.ToInt32(Console.ReadLine());
int resultado = 1;

if (numero2 <= 1)
{
    Console.WriteLine("No se permite números negativos, el número 0 o el número 1");
}
else
{
    for (int i = numero2 - 1; i >= 0; i--)
    {
        resultado = resultado * i;
        Console.WriteLine(resultado);
    }
}

//Ejercicio 3
int aux;
int primero = 0;
int segundo = 1;
Console.WriteLine("");
Console.WriteLine("Ingrese un número para realizar la secuencia Fibonnaci:");
int numero3;
numero3 = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < numero3; i++)
{
    Console.WriteLine(primero);
    aux = primero;
    primero = segundo;
    segundo = aux + segundo;
}

//Ejercicio 4

bool continuar = true;

while (continuar == true)
{
    Console.WriteLine("");
    Console.WriteLine("Inserte numeros del 1 al 3 que estan en la siguiente lista: ");
    Console.WriteLine("1 = Hola");
    Console.WriteLine("2 = Chau");
    Console.WriteLine("3 = Se termina el programa");
    Console.WriteLine("");
    int opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.WriteLine("");
            Console.WriteLine("Hola");
            Console.WriteLine("");
            break;
        case 2:
            Console.WriteLine("");
            Console.WriteLine("Chau");
            Console.WriteLine("");
            break;
        case 3:
            continuar = false;
            Console.WriteLine("");
            Console.WriteLine("Se terminó el programa");
            Console.WriteLine("");
            break;
        default:
            Console.WriteLine("");
            Console.WriteLine("El numero no esta en la lista mencionada");
            Console.WriteLine("");
            break;
    }
}

