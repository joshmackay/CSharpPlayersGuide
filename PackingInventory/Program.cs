
using PackingInventory;

Console.WriteLine("Please provide pack details:");
Console.Write("Pack maximum weight: ");
int maxWeight = Convert.ToInt32(Console.ReadLine());
Console.Write("Pack maximum volume: ");
int maxVolume = Convert.ToInt32(Console.ReadLine());
Console.Write("Pack maximum items: ");
int maxItems = Convert.ToInt32(Console.ReadLine());


Pack pack = new Pack(maxWeight, maxVolume, maxItems);

while (true)
{
    Console.WriteLine("Select an item for your pack: ");
    Console.WriteLine("1. Arrow");
    Console.WriteLine("2. Bow");
    Console.WriteLine("3. Food");
    Console.WriteLine("4. Rope");
    Console.WriteLine("5. Sword");
    Console.WriteLine("6. Water");
    int selection = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItem = selection switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Food(),
        4 => new Rope(),
        5 => new Sword(),
        6 => new Water(),
    };

    if (!pack.Add(newItem))
    {
        Console.WriteLine("Item could not be added to pack");
    }
    else
    {
        Console.WriteLine($"Current Weight: {pack.CurrentItemWeight}/{pack.MaxWeight}");
        Console.WriteLine($"Current Weight: {pack.CurrentItemVolume}/{pack.MaxVolume}");
        Console.WriteLine($"Current Weight: {pack.ItemCount}/{pack.MaxItems}");
    }

}



public class Arrow : InventoryItem{ public Arrow() : base(0.1f, 0.05f) { } }
public class Bow : InventoryItem { public Bow() : base(0.1f, 0.05f) { } }
public class Rope : InventoryItem { public Rope() : base(0.1f, 0.05f) { } }
public class Food : InventoryItem { public Food() : base(0.1f, 0.05f) { } }
public class Water : InventoryItem { public Water() : base(0.1f, 0.05f) { } }
public class Sword : InventoryItem { public Sword() : base(0.1f, 0.05f) { } }