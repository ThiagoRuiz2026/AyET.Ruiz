Console.WriteLine(Funcion2(Funcion1()));


// FUNCIÓN 1
string Funcion1()
{
    string texto;

    while (true)
    {
        Console.WriteLine("Ingrese el mensaje (solo letras y espacios):");
        texto = Console.ReadLine().ToLower();

        bool valido = true;

        for (int i = 0; i < texto.Length; i++)
        {
            char c = texto[i];

            if (!(c >= 'a' && c <= 'z') && c != ' ')
                valido = false;
        }

        if (valido) break;
        else Console.WriteLine("Error: solo letras.");
    }

    return texto;
}


// FUNCIÓN 2
string Funcion2(string texto)
{
    string abecedario = "abcdefghijklmnopqrstuvwxyz";

    Console.WriteLine("1 - Cifrar | 2 - Descifrar:");
    int opcion = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Clave:");
    int clave;

    while (!int.TryParse(Console.ReadLine(), out clave))
    {
        Console.WriteLine("Ingrese un número válido:");
    }

    string resultado = "";

    for (int i = 0; i < texto.Length; i++)
    {
        char c = texto[i];

        if (c == ' ')
        {
            resultado += ' ';
        }
        else
        {
            int pos = 0;

            for (int j = 0; j < abecedario.Length; j++)
            {
                if (c == abecedario[j])
                {
                    pos = j;
                    break;
                }
            }

            // lógica del profe
            if (opcion == 1)
                pos = pos - clave;
            else
                pos = pos + clave;

            // desbordamiento
            while (pos >= 26) pos -= 26;
            while (pos < 0) pos += 26;

            resultado += abecedario[pos];
        }
    }

    return "Resultado: " + resultado;
}

