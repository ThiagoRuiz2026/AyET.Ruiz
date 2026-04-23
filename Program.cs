//1

Console.WriteLine("ingrese una palabra para contar las vocales");
string frase = Console.ReadLine();

int contador = 0;
for (int i = 0; i < frase.Length; i++)
{
    if ("aeiouAEIOU".Contains(frase[i]))
    {
        contador++;
    }
}
Console.WriteLine("cantidad de vocales: " + contador);

//2

Console.WriteLine("Ingrese una palabra para invertirla");

string palabra = Console.ReadLine();
string invertido = "";

foreach (char letra in palabra)
{
    invertido = letra + invertido;
}
Console.WriteLine("Texto invertido: " + invertido);

//3

Console.WriteLine("ingrese un numero entero");
string numero = Console.ReadLine();
int suma = 0;
foreach (char digito in numero)
{
    suma += (digito - '0');
}
Console.WriteLine("resultado: " + suma);

//4

Console.WriteLine("Ingrese un texto: ");
string texto = Console.ReadLine();
Console.WriteLine("Palabra prohibida: ");
string prhibida = Console.ReadLine();
Console.WriteLine("palabra de remplazo: ");
string remplazo = Console.ReadLine();
string palabraActual = "";
string resultad = texto.Replace(prhibida, remplazo);
Console.WriteLine("resultado: " + resultad);

//5

Console.WriteLine("nombre: ");
string nombre = Console.ReadLine();

Console.WriteLine("Apellido: ");
string apellido = Console.ReadLine();

Console.WriteLine("Iniciales: " +
    nombre[0] + "." + apellido[0] + ".");
Console.WriteLine("nombre: " + nombre);
Console.WriteLine("apellido: " + apellido);

//6

Console.WriteLine("Palabra:");
string p = Console.ReadLine(), inv = "";

foreach (char c in p)
    inv = c + inv;
Console.WriteLine(p == inv ? "Es palindromo" : "No es palindromo");
