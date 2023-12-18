

using SimulasSoup;

(SoupType soupType, Ingredient ingredient, Seasoning seasoning) soup = GetSoup();

Console.WriteLine($"You selected {soup.seasoning}, {soup.ingredient} {soup.soupType}");

(SoupType, Ingredient, Seasoning) GetSoup()
{
    SoupType type = GetSoupType();
    Ingredient ingredient = GetIngredient();
    Seasoning seasoning = GetSeasoning();
    return (type, ingredient, seasoning);
}

SoupType GetSoupType()
{
    Console.Write($"Please select a soup type (soup, stew, gumbo): ");
    var type = Console.ReadLine().ToLower();

    return type switch
    {
        "soup" => SoupType.Soup,
        "stew" => SoupType.Stew,
        "gumbo" => SoupType.Gumbo
    };
}

Ingredient GetIngredient()
{
    Console.Write($"Please select an ingredient (mushroom, chicken, carrot, potato): ");
    var ingredient = Console.ReadLine().ToLower();

    return ingredient switch
    {
        "mushroom" => Ingredient.Mushroom,
        "chicken" => Ingredient.Chicken,
        "carrot" => Ingredient.Carrot,
        "potato" => Ingredient.Pototo
    };
}

Seasoning GetSeasoning()
{
    Console.Write($"Please select a seasoning (spicy, salty, sweet): ");
    var seasoning = Console.ReadLine().ToLower();

    return seasoning switch
    {
        "spicy" => Seasoning.Spicy,
        "salty" => Seasoning.Salty,
        "sweet" => Seasoning.Sweet
    };
}