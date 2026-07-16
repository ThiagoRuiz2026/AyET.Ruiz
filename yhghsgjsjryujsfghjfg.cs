using System.Linq.Expressions;

static double CalcularSalario(int horas)
{
    double salario;
    if (horas <= 40)
    {
        salario = horas * 16;
    }
    else
    {
        salario = (0 * 16) + ((horas - 40) * 20);
    }
    return salario;
}
static int SumarNumero()
{
    int suma = 0;
    int numero;
    while (true)
    {
        try
        {
            Console.Write("ingrese un nume (0 para terminar): ");
            numero = int.Parse(Console.ReadLine());
            if (numero == 0)
            {
                break;
            }
            suma += numero;
        }
        catch
        {
            Console.WriteLine("Dato Valido");
        }
    }
    return suma;
}

static int ConntarVocales()
{
    string palabra;
    int contador = 0;
    try
    {
        Console.Write("Inguna palabra: ");
        palabra = Console.ReadLine().ToLower();
        foreach(char letra in palabra)
        {
            if(letra == 'a' || letra == 'e' || letra == 'i' || letra == 'o' || letra == 'u')
            {
                contador++;
            }
        }
    }
    catch
    {
        Console.WriteLine("Dato invalido");
    }
    return contador;
}
static string Palindromo()
{
    string palabra = Console.ReadLine().ToLower();
    string invertida = "";
    for (int i = palabra.Length - 1; i >= 0; i--)
    {
        invertida += palabra[i];
    }
    if (palabra == invertida)
    {
        return palabra;
    }
    Console.WriteLine("No es palindromo");

}



