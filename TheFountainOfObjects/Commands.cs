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

    public class AttackCommand : ICommand
    {
        public Direction AttackDirection { get; }

        public AttackCommand(Direction shootDirection)
        {
            AttackDirection = shootDirection;
        }

        public void Execute(Game game)
        {
            var playerLoc = game.Player.Location;
            var targetLoc = AttackDirection switch
            {
                Direction.North => new Location(playerLoc.Row - 1, playerLoc.Column),
                Direction.East => new Location(playerLoc.Row, playerLoc.Column + 1),
                Direction.South => new Location(playerLoc.Row + 1, playerLoc.Column),
                Direction.West => new Location(playerLoc.Row, playerLoc.Column - 1)
            };

            foreach (var monster in game.Map.Monsters)
            {
                if (monster.Location == targetLoc)
                {
                    monster.IsAlive = false;
                    ConsoleUtilities.WriteLine($"You killed a {monster.GetType().Name}", ConsoleColor.DarkYellow);
                }
            }

        }
    }

}
