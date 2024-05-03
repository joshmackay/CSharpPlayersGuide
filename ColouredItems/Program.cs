ColouredItem<Sword> sword = new ColouredItem<Sword>(new Sword(), ConsoleColor.Red);
ColouredItem<Bow> Bow = new ColouredItem<Bow>(new Bow(), ConsoleColor.Magenta);
ColouredItem<Axe> Axe = new ColouredItem<Axe>(new Axe(), ConsoleColor.Cyan);

sword.Display();
Console.WriteLine(sword);
Bow.Display();
Console.WriteLine(Bow);
Axe.Display();
Console.WriteLine(Axe);

class ColouredItem<T>
{
    public T Item { get; set; }
    public ConsoleColor Color { get; set; }

    public ColouredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
    }
}


public class Sword { }
public class Bow { }
public class Axe { }