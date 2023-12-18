int manticoreHealth = 10;
const int manticoreStartingHealth = 10;
int cityHealth = 15;
const int cityStartingHealth = 15;
int gameRound = 1;

int cannonDamage = 0;

int manticoreDistance = -1;
int cityDistance = -1;

Console.Write("Please enter the distance of the Manticore: ");

while (manticoreDistance < 0 || manticoreDistance > 100)
{
    manticoreDistance = Convert.ToInt32(Console.ReadLine());
}

Console.Clear();

Console.WriteLine("Defender, it is your turn!");

while (manticoreHealth > 0 && cityHealth > 0)
{
    setCannonDamage(gameRound);

    Console.WriteLine("------------------------------------------------------------");
    Console.WriteLine($"STATUS:\tRound: {gameRound}\tCity: {cityHealth}/{cityStartingHealth}\tManticore: {manticoreHealth}/{manticoreStartingHealth}");
    Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
    Console.Write("Enter desired cannon range: ");
    cityDistance = Convert.ToInt32(Console.ReadLine());

    Attack(cityDistance);
    gameRound++;
}

PrintWinner();

void setCannonDamage(int round)
{
    if (round % 3 == 0 && round % 5 == 0)
    {
        cannonDamage = 10;
    }
    else if (round % 3 == 0 || round % 5 == 0)
    {
        cannonDamage = 3;
    }
    else cannonDamage = 1;
}

void Attack(int distance)
{
    if (distance < manticoreDistance)
    {
        Console.WriteLine("That round FELL SHORT of the target!");
    }
    else if (distance > manticoreDistance)
    {
        Console.WriteLine("That round OVERSHOT the target!");
    }
    else
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth -= cannonDamage;
    }
    IsManticoreAlive();

}

void IsManticoreAlive()
{
    if (manticoreHealth > 0) cityHealth -= 1;
}

void PrintWinner()
{
    Console.WriteLine($"The {(cityHealth <= 0 ? "City" : "Manticore")} has been destroyed.");
}