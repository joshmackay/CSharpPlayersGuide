
using System.Drawing;
using TheFountainOfObjects;



ConsoleUtilities.WriteLine("Welcome to The Fountain Of Objects Game!\nPlease select a game size...", ConsoleColor.Green);

int mapRows = new Int32();
int mapCols = new Int32();
int mapPits = new Int32();
int totalMaelstroms = new Int32();


Game game = Console.ReadLine() switch
{
    "small" => CreateSmallGame(),
    "medium" => CreateMediumGame(),
    "large" => CreateLargeGame(),
};
game.Run();

Game CreateSmallGame()
{
    mapRows = 4;
    mapCols = 4;
    mapPits = 1;
    totalMaelstroms = 1;

    Map map = new Map(mapRows, mapCols, mapPits, totalMaelstroms);
    Player player = new Player(new Location(0, 0));

    return new Game(player, map, totalMaelstroms);
}

Game CreateMediumGame()
{
    mapRows = 6;
    mapCols = 6;
    mapPits = 2;
    totalMaelstroms = 1;

    Map map = new Map(mapRows, mapCols, mapPits, totalMaelstroms);

    Player player = new Player(new Location(0, 0));

    return new Game(player, map, totalMaelstroms);
}

Game CreateLargeGame()
{
    mapRows = 8;
    mapCols = 8;
    mapPits = 4;
    totalMaelstroms = 2;

    Map map = new Map(mapRows, mapCols, mapPits, totalMaelstroms);

    Player player = new Player(new Location(0, 0));

    return new Game(player, map, totalMaelstroms);
}
