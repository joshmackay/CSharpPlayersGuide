using VinFletchersArrows;

Console.WriteLine("Welcome to Vin Fletchers Arrows");
Arrow arrow = GetArrow();
Console.WriteLine($"The price of your arrow is {arrow.GetCost()}");

Arrow GetArrow()
{
    Console.WriteLine("Would you like a standard arrow or a custom ordered arrow?");
    Console.WriteLine("1 -> Standard\n2 -> Custom Order");
    var selection = Convert.ToInt32(Console.ReadLine());

    return selection switch
    {
        1 => GetStandardArrow(),
        2 => GetCustomArrow()
    };
}

Arrow GetCustomArrow()
{
    Console.WriteLine("Lets make you a custom arrow!");
    ArrowHead arrowHead = GetArrowHead();
    float shaftLength = GetShaftLength();
    Fletching fletchingSelection = GetFletchingSelection();

    return new Arrow(arrowHead, shaftLength, fletchingSelection);
}

Arrow GetStandardArrow()
{
    Console.WriteLine("Please select an arrow: ");
    Console.WriteLine("1 -> Elite\n2 -> Beginner\n3 -> Markman");
    var selection = Convert.ToInt32(Console.ReadLine());
    return selection switch
    {
        1 => Arrow.CreateEliteArrow(),
        2 => Arrow.CreateBeginnerArrow(),
        3 => Arrow.CreateMarksmanArrow()
    };
}

ArrowHead GetArrowHead()
{
    Console.WriteLine("Please select an arrowhead: ");
    Console.WriteLine("1. Steel\n2. Wood\n3. Obsidian");
    int selection = Convert.ToInt32(Console.ReadLine());
    return selection switch
    {
        1 => ArrowHead.Steel,
        2 => ArrowHead.Wood,
        3 => ArrowHead.Obsidian
    };
}

float GetShaftLength()
{
    float selection = 0;

    while (selection < 60 || selection > 100)
    {
        Console.WriteLine("Please enter a shaft length (from 60cm to 100cm): ");
        selection = Convert.ToInt32(Console.ReadLine());
    }
    return selection;
}

Fletching GetFletchingSelection()
{
    Console.WriteLine("Please select your arrows fletching material: ");
    Console.WriteLine("1. Plastic\n2. Turkey Feathers\n3. Goose Feathers");
    int selection = Convert.ToInt32(Console.ReadLine());
    return selection switch
    {
        1 => Fletching.Plastic,
        2 => Fletching.TurkeyFeathers,
        3 => Fletching.GooseFeathers
    };
}