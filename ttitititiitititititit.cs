string[] pokemones =
{
"Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch'd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew"

};

string[] tipos =
{
     "Grass", "Grass", "Grass", "Fire", "Fire", "Fire", "Water", "Water", "Water", "Bug", "Bug", "Bug", "Bug", "Bug", "Bug", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Poison", "Poison", "Electric", "Electric", "Ground", "Ground", "Poison", "Poison", "Poison", "Poison", "Poison", "Poison", "Fairy", "Fairy", "Fire", "Fire", "Normal", "Normal", "Poison", "Poison", "Grass", "Grass", "Grass", "Bug", "Bug", "Bug", "Bug", "Ground", "Ground", "Normal", "Normal", "Water", "Water", "Fighting", "Fighting", "Fire", "Fire", "Water", "Water", "Water", "Psychic", "Psychic", "Psychic", "Fighting", "Fighting", "Fighting", "Grass", "Grass", "Grass", "Water", "Water", "Rock", "Rock", "Rock", "Fire", "Fire", "Water", "Water", "Electric", "Electric", "Normal", "Normal", "Normal", "Water", "Water", "Poison", "Poison", "Water", "Water", "Ghost", "Ghost", "Ghost", "Rock", "Psychic", "Psychic", "Water", "Water", "Electric", "Electric", "Grass", "Grass", "Ground", "Ground", "Fighting", "Fighting", "Normal", "Poison", "Poison", "Ground", "Ground", "Normal", "Grass", "Normal", "Water", "Water", "Water", "Water", "Water", "Water", "Psychic", "Bug", "Ice", "Electric", "Fire", "Bug", "Normal", "Water", "Water", "Water", "Normal", "Normal", "Water", "Electric", "Fire", "Normal", "Rock", "Rock", "Rock", "Rock", "Rock", "Normal", "Ice", "Electric", "Fire", "Dragon", "Dragon", "Dragon", "Psychic", "Psychic"
};

Random random = new Random();
string[,] red = new string[6, 3];
string[,] green = new string[6, 3];
string[,] blue = new string[6, 3];
string[,] yellow = new string[6, 3];

int CrearEquipo(string[,] equipo)
{
    int total = 0;
    for (int i = 0; i < 6; i++)
    {
        int indice = random.Next(pokemones.Length);
        int niveles = random.Next(50, 81);
        equipo[i, 0] = pokemones[indice];
        equipo[i, 1] = tipos[indice];
        equipo[i, 2] = niveles.ToString();

        total += niveles;
    }
    return total;
}

void MostrarEquipo(string nombre, string[,] equipo)
{
    Console.WriteLine(nombre);
    for (int i = 0; i < 0; i++)
    {
        Console.WriteLine(equipo[i, 0] + "-" +
        equipo[i, 1] + "- Nivel" +
        equipo[i, 2]);

    }
    Console.WriteLine();
}

int totalRed = CrearEquipo(red);
int totaGreen = CrearEquipo(green);
int totalBlue = CrearEquipo(blue);
int totalYellow = CrearEquipo(yellow);


MostrarEquipo("Equipo Red", red);
MostrarEquipo("Equipo Green", green);
MostrarEquipo("Equipo Blue", blue);
MostrarEquipo("Equipo Yellow", yellow);

string ganador1;
int poder1;

if (totalRed > totaGreen)
{
    ganador1 = "Red";
    poder1 = totalRed;
}
else
{
    ganador1 = "Green";
    poder1 = totaGreen;
}

Console.WriteLine("Red vs Green");
Console.WriteLine("Ganador: " + ganador1);
Console.WriteLine();

string ganador2;
int poder2;

if (totalBlue > totalYellow)
{
    ganador2 = "Blue";
    poder2 = totalBlue;
}
else
{
    ganador2 = "Yellow";
    poder2 = totalYellow;
}

Console.WriteLine("Blue vs Yellow");
Console.WriteLine("Ganador: " + ganador2);
Console.WriteLine();

string campeon;
if (poder1 > poder2)
{
    campeon = ganador1;
}
else
{
    campeon = ganador2;
}

Console.WriteLine("FINAL");
Console.WriteLine(ganador1 + "vs" + ganador2);
Console.WriteLine("Campeon del torneo" + campeon);
Console.WriteLine();




Console.WriteLine("Numeros del 50 al 0 de cinco en cinco");

MostrarNumeros(50);
void MostrarNumeros(int numero)
{
    if (numero < 0)
    {
        return;
    }
    Console.WriteLine(numero);
    MostrarNumeros(numero - 5);
}
