
        // EJERCICIO 1
        try
        {
            Console.WriteLine("Ingresá un número:");
            int n = Convert.ToInt32(Console.ReadLine());
            string resultado = ejercicio1(n);
            Console.WriteLine(resultado);
        }
        catch
        {
            Console.WriteLine("Error: ingresá un número válido.");
        }

        // EJERCICIO 2
        try
        {
            Console.WriteLine("Ingresá tu edad:");
            int edad = Convert.ToInt32(Console.ReadLine());
            string fiesta = ejercicio2(edad);
            Console.WriteLine(fiesta);
        }
        catch
        {
            Console.WriteLine("Error: ingresá una edad válida.");
        }

        // EJERCICIO 3
        try
        {
            Console.WriteLine("Ingresá la contraseña:");
            string contra = Console.ReadLine();
            string clave = ejercicio3(contra);
            Console.WriteLine(clave);
        }
        catch
        {
            Console.WriteLine("Error al ingresar la contraseña.");
        }

        // EJERCICIO 4
        try
        {
            Console.WriteLine("Ingresá un número:");
            int numpar = Convert.ToInt32(Console.ReadLine());
            string resuldiv = ejercicio4(numpar);
            Console.WriteLine(resuldiv);
        }
        catch
        {
            Console.WriteLine("Error: ingresá un número válido.");
        }

        // EJERCICIO 5
        try
        {
            Console.WriteLine("Ingresá tu edad:");
            int edading = Convert.ToInt32(Console.ReadLine());
            string regalo = ejercicio5(edading);
            Console.WriteLine(regalo);
        }
        catch
        {
            Console.WriteLine("Error: ingresá una edad válida.");
        }
    }

    // FUNCIONES

    static string ejercicio1(int n)
    {
        if (n > 0)
            return "El número es positivo";
        else if (n < 0)
            return "El número es negativo";
        else
            return "Es igual a 0";
    }

    static string ejercicio2(int edad)
    {
        if (edad >= 18)
            return "¡Bienvenido a la fiesta!";
        else if (edad >= 0)
            return "Lo siento, eres muy joven";
        else
            return "Edad no válida";
    }

    static string ejercicio3(string contra)
    {
        if (contra == "python123")
            return "¡Contraseña correcta! Acceso concedido.";
        else
            return "¡Contraseña incorrecta, autodestrucción en 5 minutos!";
    }

    static string ejercicio4(int numpar)
    {
        if (numpar % 2 == 0)
            return "El número es par.";
        else
            return "El número es impar.";
    }

    static string ejercicio5(int edading)
    {
        bool pochoclos = false;

        if (edading > 65 && pochoclos == true)
            return "¡Felicidades! Tienes entrada gratuita al cine.";
        else
            return "Compra la entrada o raja de acá";
    }
}

