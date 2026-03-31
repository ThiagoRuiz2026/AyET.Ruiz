using System.Diagnostics.CodeAnalysis;
Console.WriteLine("Ejercicio1");
for (int x = 0; x <= 10; x++){
    Console.WriteLine(x);
}
Console.WriteLine("Ejercicio2");
for (int y = 0; y <= 5; y++)
{
    Console.WriteLine("Hola");
}
Console.WriteLine("Ejercicio3");
for (int z = 0; z <= 20; z += 2)
{
    Console.WriteLine(z);
}
Console.WriteLine("Ejercicio4");
for (int a = 7; a <= 70; a += 7)
{
    Console.WriteLine(a);
    
}
Console.WriteLine("Ejercicio 5");
int suma = 0;
for (int b = 1; b <= 5; b++)
{
suma += b;
}

Console.Write("1+2+3+4+5= ");
Console.Write(suma);