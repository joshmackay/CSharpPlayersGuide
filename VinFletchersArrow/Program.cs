

using VinFletchersArrow;

(string, int P, int L) score1 = (Name: "R2-D2", Points: 12500, Level: 15);

(string Name, int P, int L) GetScore() => ("R2-D2", 12500, 15);

var score = GetScore();

Console.WriteLine(score);



Console.WriteLine("Welcome to Vins Fletching.");
Arrow arrow = GetArrow();

Console.WriteLine($"Your arrow will cost {arrow.GetCost()} gold.");

Arrow GetArrow()
{
    ArrowHead head = GetArrowHead();
    Fletching fletching = GetFletching();
    float length = GetLength();
    return new Arrow(head, fletching, length);
}

ArrowHead GetArrowHead()
{
    Console.Write("Please select an arrow head (steel, wood, obsidian): ");
    var arrowHead = Console.ReadLine();
    return arrowHead switch
    {
        "steel" => ArrowHead.Steel,
        "wood" => ArrowHead.Wood,
        "obsidian" => ArrowHead.Obsidian
    };
}

Fletching GetFletching()
{
    Console.WriteLine("Please select your fletching (plastic, turkey feather, goose feather): ");
    var fletching = Console.ReadLine();
    return fletching switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feather" => Fletching.TurkeyFeathers,
        "goose feather" => Fletching.GooseFeathers
    };
}

float GetLength()
{
    Console.WriteLine("And what length shaft? (From 60cm to 100cm): ");
    var length = Convert.ToInt32(Console.ReadLine());
    return length;
}

