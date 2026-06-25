


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[][] pokemon = new string[1][];
            pokemon[0] = [ "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch'd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew"];
            string[] tipo = { "Grass", "Grass", "Grass", "Fire", "Fire", "Fire", "Water", "Water", "Water", "Bug", "Bug", "Bug", "Bug", "Bug", "Bug", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Poison", "Poison", "Electric", "Electric", "Ground", "Ground", "Poison", "Poison", "Poison", "Poison", "Poison", "Poison", "Fairy", "Fairy", "Fire", "Fire", "Normal", "Normal", "Poison", "Poison", "Grass", "Grass", "Grass", "Bug", "Bug", "Bug", "Bug", "Ground", "Ground", "Normal", "Normal", "Water", "Water", "Fighting", "Fighting", "Fire", "Fire", "Water", "Water", "Water", "Psychic", "Psychic", "Psychic", "Fighting", "Fighting", "Fighting", "Grass", "Grass", "Grass", "Water", "Water", "Rock", "Rock", "Rock", "Fire", "Fire", "Water", "Water", "Electric", "Electric", "Normal", "Normal", "Normal", "Water", "Water", "Poison", "Poison", "Water", "Water", "Ghost", "Ghost", "Ghost", "Rock", "Psychic", "Psychic", "Water", "Water", "Electric", "Electric", "Grass", "Grass", "Ground", "Ground", "Fighting", "Fighting", "Normal", "Poison", "Poison", "Ground", "Ground", "Normal", "Grass", "Normal", "Water", "Water", "Water", "Water", "Water", "Water", "Psychic", "Bug", "Ice", "Electric", "Fire", "Bug", "Normal", "Water", "Water", "Water", "Normal", "Normal", "Water", "Electric", "Fire", "Normal", "Rock", "Rock", "Rock", "Rock", "Rock", "Normal", "Ice", "Electric", "Fire", "Dragon", "Dragon", "Dragon", "Psychic", "Psychic" };
            string[,] blue = new string[6, 3];
            string[,] red = new string[6, 3];
            string[,] yellow = new string[6, 3];
            string[,] green = new string[6, 3];



            blue = llenarequipo(blue);
            green = llenarequipo(green);
            red = llenarequipo(red);
            yellow = llenarequipo(yellow);






            bool ganador1, ganador2, ganadorfinal;
            ganador1 = determinarganador(red, green);
            ganador2 = determinarganador(yellow, blue);
            if (ganador1 == true && ganador2 == true)
            {
                ganadorfinal = determinarganador(red, yellow);
            }
            else if (ganador1 == true && ganador2 == false)
            {
                ganadorfinal = determinarganador(red, blue);
            }
            else if (ganador1 == false && ganador2 == true)
            {
                ganadorfinal = determinarganador(green, yellow);
            }
            else
            {
                ganadorfinal = determinarganador(green, blue);
            }


            string final1 = nombre(ganador1, "red", "green");
            string final2 = nombre(ganador2, "yellow", "blue");
            Console.WriteLine("pelea 1 el ganador es: " + final1);
            Console.WriteLine("pelea 2 el ganador es: " + final2);

            string mostrarganador = nombre(ganadorfinal, final1, final2);
            Console.WriteLine("el ganador del torneo es" + mostrarganador);
            switch (mostrarganador)
            {
                case "red":
                    mostrar(red);
                    break;
                case "green":
                    mostrar(green);
                    break;
                case "yellow":
                    mostrar(yellow);
                    break;
                case "blue":
                    mostrar(blue);
                    break;
            }

            bool determinarganador(string[,] equipo1, string[,] equipo2)
            {
                int nivel1 = 0;
                int nivel2 = 0;
                for (int x = 0; x < equipo1.GetLength(0); x++)
                {
                    nivel1 += Convert.ToInt32(equipo1[x, 2]);
                    nivel2 += Convert.ToInt32(equipo2[x, 2]);
                }

                if (nivel1 > nivel2)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            string[,] llenarequipo(string[,] equipo)
            {
                Random aleatorio = new Random();

                for (int x = 0; x < equipo.GetLength(0); x++)
                {
                    int eleccion = aleatorio.Next(0, 151);
                    int nivel = aleatorio.Next(50, 81);
                    for (int y = 0; y < equipo.GetLength(1); y++)
                    {
                        switch (y)
                        {
                            case 0:
                                equipo[x, y] = pokemon[0][eleccion];
                                break;
                            case 1:
                                equipo[x, 1] = tipo[eleccion];
                                break;
                            case 2:
                                equipo[x, 2] = nivel.ToString();
                                break;
                        }

                    }
                }
                return equipo;
            }

            string nombre(bool ganador, string nombre1, string nombre2)
            {
                if (ganador)
                {
                    return nombre1;
                }
                else
                {
                    return nombre2;
                }
            }

            void mostrar(string[,] equipo)
            {
                for (int x = 0; x < equipo.GetLength(0); x++)
                {
                    for (int y = 0; y < equipo.GetLength(1); y++)
                    {
                        Console.Write(equipo[x, y] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
