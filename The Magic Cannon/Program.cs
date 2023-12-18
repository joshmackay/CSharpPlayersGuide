for (var shot = 1; shot <= 100; shot++)
{
    if (shot % 3 == 0 && shot % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("POWER SHOT!!!");
    }
    else if (shot % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Fire shot!");
    }
    else if (shot % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Electric shot!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Normal shot!");
    }
}