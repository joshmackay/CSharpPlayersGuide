Console.Write("What is your name? ");
var name = Console.ReadLine();
bool discount = name.ToLower() == "josh" ? true : false;
Console.WriteLine($"{(discount ? "Discount applied" : "Standard prices apply")}");

Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");


while (true)
{
    Console.Write("What item do you want to see the price of? ");
    var itemNumber = Console.ReadLine();

    var item = itemNumber switch
    {
        "1" => "Rope",
        "2" => "Torches",
        "3" => "Climbing Equipment",
        "4" => "Clean Water",
        "5" => "Machete",
        "6" => "Canoe",
        "7" => "Food Supplies",
    };

    var itemPrice = item switch
    {
        "Rope" => 10,
        "Torches" => 15,
        "Climbing Equipment" => 25,
        "Clean Water" => 1,
        "Machete" => 20,
        "Canoe" => 200,
        "Food Supplies" => 1
    };

    Console.WriteLine($"{item} costs {(discount ? itemPrice / 2.0 : itemPrice)} gold.");
}