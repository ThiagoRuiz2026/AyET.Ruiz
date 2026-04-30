using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

string ejercicio1(int n)
{
    string resultado;
    if (n > 0)
    {
        resultado = "el numero es positivo";
        return resultado;
    }
    else if (n < 0)
    {
        resultado = "el numero es negativo";
        return resultado;
    }
    else
    {
        resultado = "es igual a 0";
        return resultado;
    }

}

int n = Convert.ToInt32(Console.ReadLine());
string resultado = ejercicio1(n);
Console.WriteLine(resultado);

string ejercicio2(int edad)
{
    string fiesta;
    if (edad >= 18)
    {
        fiesta = "¡Bienvenido a la fiesta!";
        return fiesta;

    }
    else if (edad >= 0)
    {
        fiesta = "Lo siento, eres muy joven";
        return fiesta;
    }
    else
    {
        fiesta = "edad no valida";
        return fiesta;
    }

}

int edad = Convert.ToInt32(Console.ReadLine());
string fiesta = ejercicio2(edad);
Console.WriteLine(fiesta);

string ejercicio3(string contra)
{
    string python123 = Console.ReadLine();
    string clave;
    if (contra == python123)
    {
        clave = " ¡Contraseña correcta! Acceso concedido.";
        return clave;
    }
    else
    {
        clave = "¡Contraseña incorrecta, Autodestrucción en 5 minutos!";
        return clave;
    }

}

string contra = Convert.ToString(Console.ReadLine());
string clave = ejercicio3(contra);
Console.WriteLine(clave);
int numpar = Convert.ToInt32(Console.ReadLine());
string ejercicio4(int numpar)
{
    string resuldiv;
    if (numpar % 2 == 0)
    {
        resuldiv = "El numero es par.";
        return resuldiv;
    }
    else
    {
        resuldiv = "El numero es impar.";
        return resuldiv;
    }

}

int contras = Convert.ToInt32(Console.ReadLine());
string resuldiv = ejercicio4(numpar);
Console.WriteLine(resuldiv);

string ejercicio5(int edading)
{
    string regalo;
    bool pochoclos = false;
    if (edading > 65 && pochoclos == true)
    {
        regalo = "¡Felicidades! Tienes entrada gratuita al cine.";
        return regalo;
    }
    else
    {
        regalo = "Compra la entrada o raja de acá";
        return regalo;
    }

}
int edading = Convert.ToInt32(Console.ReadLine());
string regalo = ejercicio5(numpar);
Console.WriteLine(regalo);

