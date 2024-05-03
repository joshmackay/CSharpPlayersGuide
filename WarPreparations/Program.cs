
Sword basic = new Sword(Material.Iron, GemStone.None, 100, 25);
Sword variation1 = basic with { material = Material.Binarium, GemStone = GemStone.Bitstone, length = 200, crossguardLength = 45 };
Sword variation2 = basic with { material = Material.Steel, GemStone = GemStone.Diamond, length = 150, crossguardLength = 45 };

Console.WriteLine(basic.ToString());
Console.WriteLine(variation1.ToString());
Console.WriteLine(variation2.ToString());

enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

enum GemStone
{
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
    None
}

record Sword(Material material, GemStone GemStone, int length, int crossguardLength);