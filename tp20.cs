using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    
    class AccionTexto
    {
        public string TipoAccion { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaHora { get; set; }

        public AccionTexto(string tipoAccion, string contenido)
        {
            TipoAccion = tipoAccion;
            Contenido = contenido;
            FechaHora = DateTime.Now;
        }
    }


    

    class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Prioridad { get; set; }
        public int EstimacionMinutos { get; set; }

        public Tarea(int id, string titulo, int prioridad, int estimacionMinutos)
        {
            Id = id;
            Titulo = titulo;
            Prioridad = prioridad;
            EstimacionMinutos = estimacionMinutos;
        }

        public void Mostrar()
        {
            Console.WriteLine(
                $"ID: {Id} | Título: {Titulo} | " +
                $"Prioridad: {Prioridad} | " +
                $"Estimación: {EstimacionMinutos} minutos"
            );
        }
    }


    internal class Program
    {
        
        static void InvertirPalabra()
        {
            Console.WriteLine("EJERCICIO 1");
            Console.Write("Ingrese una palabra o frase: ");

            string texto = Console.ReadLine();

            Queue<char> cola = new Queue<char>();

            foreach (char caracter in texto)
            {
                cola.Enqueue(caracter);
            }

            char[] resultado = new char[texto.Length];

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                resultado[i] = cola.Dequeue();
            }

            Array.Reverse(resultado);

            Console.WriteLine("Resultado: " + new string(resultado));
        }


        

        static void Navegador()
        {
            Console.WriteLine("\nEJERCICIO 2");

            Stack<string> historial = new Stack<string>();

            string paginaActual = "Inicio";

            while (true)
            {
                Console.WriteLine("\nPágina actual: " + paginaActual);

                Console.WriteLine("1 - Visitar nueva página");
                Console.WriteLine("2 - Atrás");
                Console.WriteLine("3 - Salir");

                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.Write("Ingrese la URL: ");
                    string nuevaPagina = Console.ReadLine();

                    historial.Push(paginaActual);
                    paginaActual = nuevaPagina;
                }
                else if (opcion == "2")
                {
                    if (historial.Count > 0)
                    {
                        paginaActual = historial.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No hay páginas anteriores.");
                    }
                }
                else if (opcion == "3")
                {
                    break;
                }
            }
        }


        

        static bool DelimitadoresCorrectos(string expresion)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char caracter in expresion)
            {
                if (caracter == '(' ||
                    caracter == '[' ||
                    caracter == '{')
                {
                    pila.Push(caracter);
                }
                else if (caracter == ')' ||
                         caracter == ']' ||
                         caracter == '}')
                {
                    if (pila.Count == 0)
                        return false;

                    char abierto = pila.Pop();

                    if (caracter == ')' && abierto != '(')
                        return false;

                    if (caracter == ']' && abierto != '[')
                        return false;

                    if (caracter == '}' && abierto != '{')
                        return false;
                }
            }

            return pila.Count == 0;
        }


        
        static void GestorTexto()
        {
            Console.WriteLine("\nEJERCICIO 4");

            Stack<AccionTexto> historial = new Stack<AccionTexto>();

            historial.Push(
                new AccionTexto("Escribir", "Hola")
            );

            historial.Push(
                new AccionTexto("Escribir", " mundo")
            );

            historial.Push(
                new AccionTexto("Borrar", "mundo")
            );

            Console.WriteLine("Acciones realizadas:");

            foreach (AccionTexto accion in historial)
            {
                Console.WriteLine(
                    accion.TipoAccion + " - " +
                    accion.Contenido + " - " +
                    accion.FechaHora
                );
            }

            Console.WriteLine("\nDeshaciendo última acción...");

            if (historial.Count > 0)
            {
                AccionTexto accion = historial.Pop();

                Console.WriteLine(
                    "Se deshizo: " +
                    accion.TipoAccion +
                    " - " +
                    accion.Contenido
                );
            }

            Console.WriteLine("\nAcciones restantes:");

            foreach (AccionTexto accion in historial)
            {
                Console.WriteLine(
                    accion.TipoAccion + " - " +
                    accion.Contenido
                );
            }
        }


       
        static double CalcularRPN(string expresion)
        {
            Stack<double> pila = new Stack<double>();

            string[] elementos = expresion.Split(' ');

            foreach (string elemento in elementos)
            {
                if (double.TryParse(elemento, out double numero))
                {
                    pila.Push(numero);
                }
                else
                {
                    double segundo = pila.Pop();
                    double primero = pila.Pop();

                    switch (elemento)
                    {
                        case "+":
                            pila.Push(primero + segundo);
                            break;

                        case "-":
                            pila.Push(primero - segundo);
                            break;

                        case "*":
                            pila.Push(primero * segundo);
                            break;

                        case "/":
                            pila.Push(primero / segundo);
                            break;
                    }
                }
            }

            return pila.Pop();
        }


        
        static void ProcesarTareas()
        {
            Console.WriteLine("\nEJERCICIO 6");

            Stack<Tarea> tareas = new Stack<Tarea>();

            tareas.Push(
                new Tarea(1, "Hacer informe", 2, 30)
            );

            tareas.Push(
                new Tarea(2, "Estudiar C#", 3, 60)
            );

            tareas.Push(
                new Tarea(3, "Hacer TP", 1, 45)
            );

            Console.WriteLine("Tarea en la cima:");

            if (tareas.Count > 0)
            {
                tareas.Peek().Mostrar();
            }

            Console.WriteLine("\nAtendiendo tareas:");

            while (tareas.Count > 0)
            {
                Tarea tarea = tareas.Pop();

                tarea.Mostrar();
            }
        }


        

        static void Main(string[] args)
        {
            // EJERCICIO 1
            InvertirPalabra();

            // EJERCICIO 2
            Navegador();

            // EJERCICIO 3
            Console.WriteLine("\nEJERCICIO 3");

            Console.WriteLine(
                DelimitadoresCorrectos("{ [ ( a + b ) ] }")
            );

            Console.WriteLine(
                DelimitadoresCorrectos("{ [ ( a + b } ] )")
            );

            // EJERCICIO 4
            GestorTexto();

            // EJERCICIO 5
            Console.WriteLine("\nEJERCICIO 5");

            Console.Write("Ingrese una expresión RPN: ");
            string expresion = Console.ReadLine();

            double resultado = CalcularRPN(expresion);

            Console.WriteLine("Resultado: " + resultado);

            // EJERCICIO 6
            ProcesarTareas();

            Console.WriteLine("\nPresione una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
