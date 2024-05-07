using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public abstract class Monster
    {
        public Location Location { get; set; }
        public bool IsAlive { get; set; }
        public Monster(Location startLocation)
        {
            Location = startLocation;
            IsAlive = true;
        }

        public abstract void Activate(Game game);

    }

    public class Maelstrom : Monster
    {

        public Maelstrom(Location location) : base(location) { }

        public override void Activate(Game game)
        {
            
            int newRowPos = (game.Map.MapRows + this.Location.Row + 1) % game.Map.MapRows;
            int newColPos = (game.Map.MapCols + this.Location.Column - (2 % game.Map.MapCols)) % game.Map.MapCols;
            this.Location = new Location(newRowPos, newColPos);

            int newPlayerRow = (game.Map.MapRows + game.Player.Location.Row - (1 % game.Map.MapRows)) % game.Map.MapRows;
            int newPlayerCol = (game.Map.MapCols + game.Player.Location.Column + 2) % game.Map.MapCols;
            game.Player.Location = new Location(newPlayerRow, newPlayerCol);

            ConsoleUtilities.WriteLine("You encountered a MAELSTROM!", ConsoleColor.Magenta);
            ConsoleUtilities.WriteLine($"You have been moved to Row: {newPlayerRow}, Column: {newPlayerCol}", ConsoleColor.Magenta);
            ConsoleUtilities.WriteLine($"The Maelstrom moved to a new location.", ConsoleColor.Magenta);
        }

    }
}
