// 1
Console.WriteLine("Multiplos de 3 del 1 al 100:");
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0)
        Console.WriteLine(i);
}


//2
Console.WriteLine("Ingrese edad:");
int edad = int.Parse(Console.ReadLine());

if (edad < 18)
    Console.WriteLine("Menor");
else if (edad == 18)
    Console.WriteLine("18");
else
    Console.WriteLine("Mayor"); --


//3
Console.WriteLine("Ingrese una palabra:");
string palabra = Console.ReadLine();
Console.WriteLine("Cantidad de letras: " + palabra.Length);


//4
Console.WriteLine("Adivine la contraseña (5 intentos):");
string pass = "1234";

for (int i = 0; i < 5; i++)
{
    string intento = Console.ReadLine();

    if (intento == pass)
    {
        Console.WriteLine("Correcto");
        break;
    }

    if (i == 4)
        Console.WriteLine("Bloqueado");
}


//5
Console.WriteLine("Ingrese 10 numeros:");
int mayor = int.MinValue;

for (int i = 0; i < 10; i++)
{
    int n = int.Parse(Console.ReadLine());

    if (n > mayor)
        mayor = n;
}

Console.WriteLine("Mayor: " + mayor);


//6
Console.WriteLine("Ingrese su nombre:");
string nombre = Console.ReadLine();
Console.WriteLine(char.ToUpper(nombre[0]) + nombre.Substring(1));


//7
Console.WriteLine("Tabla del 7:");
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine("7 x " + i + " = " + (7 * i));
}


//8
Console.WriteLine("Cuenta regresiva:");
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine(i);
}
Console.WriteLine("oa");


//9
Console.WriteLine("Ingrese un numero:");
int num9 = int.Parse(Console.ReadLine());

if (num9 % 2 == 0)
    Console.WriteLine("par");
else
    Console.WriteLine("impar");


//10
Console.WriteLine("Ingrese una frase:");
string frase10 = Console.ReadLine().ToLower();

int cont10 = 0;

foreach (char c in frase10)
{
    if ("aeiou".Contains(c))
        cont10++;
}

Console.WriteLine("Vocales: " + cont10);


//11
Console.WriteLine("Ingrese un numero:");
int num11 = int.Parse(Console.ReadLine());

for (int i = 1; i <= 12; i++)
{
    Console.WriteLine(num11 + " x " + i + " = " + (num11 * i));
}


//12
Console.WriteLine("Ingrese numeros hasta superar 100:");
int suma = 0;

while (suma <= 100)
{
    suma += int.Parse(Console.ReadLine());
}

Console.WriteLine("Supero 100");


//13
Console.WriteLine("Ingrese una palabra:");
string palabra13 = Console.ReadLine();

foreach (char c in palabra13)
{
    Console.WriteLine(c);
}


//14
Console.WriteLine("Ingrese edad:");
int edad14 = int.Parse(Console.ReadLine());

if (edad14 >= 18)
    Console.WriteLine("Puede votar y manejar");
else
    Console.WriteLine("No puede");


//15
Console.WriteLine("De 50 a 0 de 5 en 5:");
for (int i = 50; i >= 0; i -= 5)
{
    Console.WriteLine(i);
}


//16
Console.WriteLine("Ingrese contraseña y repitala:");
string a, b;

do
{
    a = Console.ReadLine();
    b = Console.ReadLine();

} while (a != b);

Console.WriteLine("Acceso permitido");


//17
Console.WriteLine("Ingrese nombres hasta que uno tenga mas de 10 letras:");
string nombre17;

do
{
    nombre17 = Console.ReadLine();

} while (nombre17.Length <= 10);


//18
Console.WriteLine("Ingrese una frase:");
string frase18 = Console.ReadLine().ToLower();

int cont18 = 0;

foreach (char c in frase18)
{
    if (c == 'a')
        cont18++;
}

Console.WriteLine("Cantidad de 'a': " + cont18);

