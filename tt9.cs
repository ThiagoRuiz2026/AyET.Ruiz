//Ejercicio N°1
Console.WriteLine("ingrese la contraseña");
string clave;
clave = Console.ReadLine();

while (clave != "BocaJr2000")
{
    Console.WriteLine("");
    Console.WriteLine("Intentelo de nuevo");
    clave = Console.ReadLine();
}
Console.WriteLine("");
Console.WriteLine("Entrando...");


//Ejercicio N°2
Console.WriteLine("");
Console.WriteLine("Preparandose para el despegue:");
int contador;

for (contador = 1; contador <= 5; contador++)
{
    Console.WriteLine(contador);
}
Console.WriteLine("");
Console.WriteLine("Listo para despegar bro");
Console.WriteLine("");
Console.WriteLine("¡Hasta la vista!");

//Ejercicio N°3
Console.WriteLine("");
Console.WriteLine("Adivina el numero");
int numero = Convert.ToInt32(Console.ReadLine());

while (numero != 26)
{
    Console.WriteLine("incorrecto, inserte otro número:");
    numero = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Adivinaste bro");

//Ejercicio N°4

Console.WriteLine("");
Console.WriteLine("Escriba algunos números para sumarlos");
Console.WriteLine("Si quiere terminar el proceso, escriba el número 0");

int suma = 0;
int valor = Convert.ToInt32(Console.ReadLine());

while (valor != 0)
{
    suma = suma + valor;
    valor = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("");
Console.WriteLine("La suma de todos lso numeros que escribio es:");
Console.WriteLine(suma);

