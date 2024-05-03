using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public interface ICommand
    {
        public void Execute(Game game);
    }

    public class MoveCommand : ICommand
    {
        public Direction Direction { get; }

        public MoveCommand(Direction direction)
        {
            Direction = direction;
        }

        public void Execute(Game game)
        {
            Location currentLocation = game.Player.Location;

            Location newLocation = Direction switch
            {
                Direction.North => new Location(currentLocation.Row - 1, currentLocation.Column),
                Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1),
                Direction.South => new Location(currentLocation.Row + 1, currentLocation.Column),
                Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1),
            };

            if (game.Map.IsOnMap(newLocation))
            {
                game.Player.Location = newLocation;
            }
            else
            {
                ConsoleUtilities.WriteLine("There is a wall there.", ConsoleColor.Red);
            }
        }
    }

    public class EnableFountainCommand : ICommand
    {
        public void Execute(Game game)
        {
            game.IsFountainActive = !game.IsFountainActive;
            ConsoleUtilities.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Green);
        }
    }

}
