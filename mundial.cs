using System;
using System.Collections.Generic;

struct Jugador
{
    public string Nombre;
    public string Apellido;
    public int CantGoles;
    public int CantDisparos;
    public int NumeroCamiseta;
    public string Posicion;
    public string Equipo;

    public Jugador(string nombre, string apellido, int cantGoles,
                   int cantDisparos, int numeroCamiseta,
                   string posicion, string equipo)
    {
        Nombre = nombre;
        Apellido = apellido;
        CantGoles = cantGoles;
        CantDisparos = cantDisparos;
        NumeroCamiseta = numeroCamiseta;
        Posicion = posicion;
        Equipo = equipo;
    }

    public double IndiceAtaque()
    {
        if (CantDisparos == 0)
            return 0;

        return ((double)CantGoles / CantDisparos) * 100;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Nombre: {Nombre} {Apellido}");
        Console.WriteLine($"Goles: {CantGoles}");
        Console.WriteLine($"Disparos: {CantDisparos}");
        Console.WriteLine($"Camiseta: {NumeroCamiseta}");
        Console.WriteLine($"Posición: {Posicion}");
        Console.WriteLine($"Equipo: {Equipo}");
        Console.WriteLine($"Índice de ataque: {IndiceAtaque():F2}%");
        Console.WriteLine();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        List<Jugador> jugadores = new List<Jugador>();

        Console.Write("¿Cuántos jugadores desea ingresar?: ");
        int cantidad = int.Parse(Console.ReadLine());

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\nJugador {i + 1}");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Cantidad de goles: ");
            int goles = int.Parse(Console.ReadLine());

            Console.Write("Cantidad de disparos al arco: ");
            int disparos = int.Parse(Console.ReadLine());

            Console.Write("Número de camiseta: ");
            int camiseta = int.Parse(Console.ReadLine());

            Console.Write("Posición: ");
            string posicion = Console.ReadLine();

            Console.Write("Equipo: ");
            string equipo = Console.ReadLine();

            Jugador jugador = new Jugador(
                nombre,
                apellido,
                goles,
                disparos,
                camiseta,
                posicion,
                equipo
            );

            jugadores.Add(jugador);
        }

        Jugador mejorJugador = jugadores[0];

        foreach (Jugador jugador in jugadores)
        {
            if (jugador.IndiceAtaque() > mejorJugador.IndiceAtaque())
            {
                mejorJugador = jugador;
            }
        }

        Console.WriteLine("\n===== JUGADOR CON MEJOR ÍNDICE DE ATAQUE =====");
        mejorJugador.Mostrar();

        Console.ReadKey();
    }
}
