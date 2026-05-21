//Ejercicio1 
Console.WriteLine("Ejercicio 1");
Console.WriteLine(
"Thigo; Jose; Manteca; Papa; Jeremy; Boee; Que Manda; D de Dabo; Jabon; Aura");
string[] nombres = {
"Thigo",
"Jose",
"Manteca",
"Papa",
"Jeremy",
"Boee",
"Que Mandan",
"D de Dabo",
"Jabon",
"Aura"
};
string palabraMasLarga =
    nombres [0];
for (int i = 0; i < nombres.Length; i++)
{
    if (nombres[i].Length > palabraMasLarga.Length)
    {
        palabraMasLarga = nombres[i];
    }
}
Console.WriteLine("La palabra mas larga es: " + palabraMasLarga);


//2
Console.WriteLine("Ejercicio 2");
int cantidadVocales = 0;
for (int i = 0; i < nombres.Length; i++)
{
    string palabra = nombres[i].ToLower();
    for (int j = 0; j < palabra.Length; j++)
    {
        char letra = palabra[j];
        if (letra == 'a'|| letra == 'e'|| letra == 'i'|| letra == 'o'|| letra == 'u')
        {
            cantidadVocales++;
        }
    }
}
Console.WriteLine("La cantidad de vocales de las 10 palabras son: " + cantidadVocales);

//3

Console.WriteLine("ejercicio 3");

int[] numero = { 1, 2, 3, 4, 5, };
int factor = 3;

int[] nuevaLista = new
    int[numero.Length];
for (int i = 0; i < numero.Length; i++)
{
    nuevaLista[i] = numero[i] * factor;
}
Console.WriteLine("nueva lista multiplicada");

for (int i = 0; i < nuevaLista.Length; i++)
{
    Console.Write(nuevaLista[i] + "");
}
Console.ReadKey();