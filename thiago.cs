
//tp

Console.WriteLine("ingrese un numero para generar  la factorial");
int aceite = Convert.ToInt32(Console.ReadLine());

int xd = 1;
for (int Thiago = 1; Thiago <= aceite; Thiago++)
{
    xd = xd * Thiago;

   
}
while (aceite < xd)
{
    Console.WriteLine("reintenta");
    if (aceite < 0)
    {

    }
    else
    {
        Console.WriteLine("Intentelo de nuevo");
    }
    aceite = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("el factorial de tu numero es: " + xd);

