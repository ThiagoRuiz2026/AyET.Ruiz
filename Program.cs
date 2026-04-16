bool continuar = true;
while (continuar == true)
{
    Console.WriteLine("ingrese un numero");
    Console.WriteLine("1 = Ejercicio1, 2 = Ejercicio2, 3 = Ejercicio3, 4 = Ejercicio4, 5 = Ejercicio5, 0 = cierre del programa");
    int x = Convert.ToInt16(Console.ReadLine());

    switch (x)
    {
        case 1:
            Console.WriteLine("ingrese un numero para ver si es positivo");
            Console.WriteLine(Ejercicio1(Convert.ToInt32(Console.ReadLine())));
            break;
        case 2:
            Console.WriteLine("ingrese su edad");
            Console.WriteLine(Ejercicio2(Convert.ToInt32(Console.ReadLine())));
            break;
        case 3:
            Console.WriteLine("ingrese su contraseña");
            Console.WriteLine(Ejercicio3(Console.ReadLine()));
            break;
        case 4:
            Console.WriteLine("ingrese un numero para ver si es par");
            Console.WriteLine(Ejercicio4(Convert.ToInt32(Console.ReadLine())));
            break;
        case 5:
            Console.WriteLine("ingrese su edad");
            Console.WriteLine(Ejercicio4(Convert.ToInt32(Console.ReadLine())));
            break;
        case 0:
            continuar = false;
            break;
        default:
            Console.WriteLine("numero incorrecto");
            break;
    }
}
string Ejercicio1(int n)

{
    string resultado;
    if (n > 0)
    {
        resultado = ("Positivo");
        return resultado;
    }
    else
    {
        resultado = ("negativo");
        return resultado;
    }

}
string Ejercicio2(int E)
{
    string Resultado2;

    if (E >= 18)
    {
        Resultado2 = ("Bienvenido a la fiesta");
        return Resultado2;
    }
    else
    {
        Resultado2 = ("Lo sinto, eres muy joven");
        return Resultado2;
    }

}
string Ejercicio3(string C)
{
    C = Console.ReadLine();
    string Resultado3;
    if (C == ("Phyton123"))
    {
        Resultado3 = ("Bienvenido");
        return Resultado3;
    }
    else
    {
        Resultado3 = ("Contraseña incorrecta, este dispositivo se autodestruira");
        return Resultado3;
    }

}
string Ejercicio4(int n)
{
    string resultado4;

    if (n % 2 == 0)
    {
        resultado4 = ("El numero es par");
        return resultado4;
    }
    else
    {
        resultado4 = ("El numero es impar");
        return resultado4;
    }
}
string Ejercicio5(int E, string P)
{

    Console.WriteLine("Ejercicio 5, Ingrese su edad");
    int edad = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("¿Compraste palomitas? (si/no)");
    string palomitas = Console.ReadLine();

    string resultado5;

    if (E > 65 && P == "si")
    {
        resultado5 = ("Felicidades! Tenes entrada gratuita al cine");
        return resultado5;
    }
    else
    {
        resultado5 = ("Compra la entrada o raja de aca");
        return resultado5;
    }
}
