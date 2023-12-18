using TheCard;

var colors = (Color[])Enum.GetValues(typeof(Color));
var ranks = (Rank[])Enum.GetValues(typeof(Rank));

foreach (var color in colors)
{
    foreach (var rank in ranks)
    {
        Card card = new Card(color, rank);
        Console.WriteLine($"The {color} {rank}.");
    }
}