Console.WriteLine("Elegí un número para jugar:");
Console.WriteLine("1: palabra 1");
Console.WriteLine("2: palabra 2");
Console.WriteLine("3: palabra 3");

int opcion = Convert.ToInt32(Console.ReadLine());
char letra = ' ';
string palabra = "";

if (opcion == 1)
{
    palabra = "tecnologia";
}
else if (opcion == 2)
{
    palabra = "algoritmos";
}
else
{
    palabra = "computadora";
}

string progreso = "";

for (int i = 0; i < palabra.Length; i++)
{
    progreso += "_";
}

int intentos = 7;
bool gano = false;

while (intentos > 0 && !gano)
{
    Console.WriteLine("");
    Console.WriteLine("Palabra: " + progreso);
    Console.WriteLine("Intentos restantes: " + intentos);
    Console.WriteLine("Ingrese una letra:");

    try
    {
        letra = Convert.ToChar(Console.ReadLine());
    }
    catch (System.FormatException) {
        Console.WriteLine("el caracter que pusiste no es valido");
    }   
    bool encontro = false;
    string nuevo = "";


    for (int i = 0; i < palabra.Length; i++)
    {
        if (palabra[i] == letra)
        {
            nuevo += letra;
            encontro = true;
        }
        else
        {
            nuevo += progreso[i];
        }
    }


    progreso = nuevo;


    if (encontro == false)
    {
        intentos--;
        Console.WriteLine("Letra incorrecta");
    }
    else
    {
        Console.WriteLine("Bien! Letra encontrada");
    }


    if (progreso == palabra)
    {
        gano = true;
    }
}


Console.WriteLine("");

if (gano)
{
    Console.WriteLine("Ganaste! La palabra era: " + palabra);
}
else
{
    Console.WriteLine("Perdiste! La palabra era: " + palabra);
}

