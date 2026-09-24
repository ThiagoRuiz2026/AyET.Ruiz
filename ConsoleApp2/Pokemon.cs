namespace ConsoleApp2
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public int Hp { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int AtaqueEspecial { get; set; }
        public int DefensaEspecial { get; set; }
        public int Velocidad { get; set; }
        public int Nivel { get; set; }

        public void Mostrar()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Tipo 1: " + Tipo1);
            Console.WriteLine("Tipo 2: " + (Tipo2 ?? "Ninguno"));
            Console.WriteLine("HP: " + Hp);
            Console.WriteLine("Ataque: " + Ataque);
            Console.WriteLine("Defensa: " + Defensa);
            Console.WriteLine("Ataque especial: " + AtaqueEspecial);
            Console.WriteLine("Defensa especial: " + DefensaEspecial);
            Console.WriteLine("Velocidad: " + Velocidad);
            Console.WriteLine("Nivel: " + Nivel);
        }
    }
}
