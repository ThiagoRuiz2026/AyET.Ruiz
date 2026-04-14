Console.WriteLine("Ejecicio 1");
string Ejercico1(int n)

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
Console.WriteLine(Ejercico1(Convert.ToInt32(Console.ReadLine())));


Console.WriteLine("Ejercicio 2, Ingrese su edad");
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
Console.WriteLine(Ejercicio2(Convert.ToInt32(Console.ReadLine())));

Console.WriteLine("Ejercicio 3, Ingrese su contraseña");
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
Console.WriteLine(Ejercicio3((Console.ReadLine())));
Console.WriteLine("Ejercicio 4, Ingrese un numero");

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

Console.WriteLine(Ejercicio4(Convert.ToInt32(Console.ReadLine())));



Console.WriteLine("Ejercicio 5, Ingrese su edad");
int edad = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("¿Compraste palomitas? (si/no)");
string palomitas = Console.ReadLine();


string Ejercicio5(int E, string P)
{
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

Console.WriteLine(Ejercicio5(edad, palomitas));
