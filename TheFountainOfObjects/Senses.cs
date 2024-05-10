using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public interface ISense
    {
        public bool CanSense(Game game);
        public void DisplaySense(Game game);
    }

    public class NoSense : ISense
    {
        public bool CanSense(Game game)
        {
            return game.CurrentRoom == RoomType.Normal;
        }

        public void DisplaySense(Game game)
        {
            ConsoleUtilities.WriteLine("There is nothing here...", ConsoleColor.Gray);
        }
    }

    public class ExitSense : ISense
    {
        public bool CanSense(Game game)
        {
            return game.CurrentRoom == RoomType.Exit;
        }

        public void DisplaySense(Game game)
        {
            ConsoleUtilities.WriteLine("You see light coming from the cavern entrance.", ConsoleColor.DarkYellow);
        }
    }

    public class FountainSense : ISense
    {
        public bool CanSense(Game game)
        {
            return game.CurrentRoom == RoomType.Fountain;
        }

        public void DisplaySense(Game game)
        {
            if (game.IsFountainActive)
                ConsoleUtilities.WriteLine("You hear rushing water, the fountain of objects is active!", ConsoleColor.Green);
            else
                ConsoleUtilities.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Cyan);
        }
    }

    public class PitBreezeSense : ISense
    {
        public bool CanSense(Game game)
        {
            return game.CheckAdjacentRoomsForRoomType(game.Player.Location, RoomType.Pit);
        }

        public void DisplaySense(Game game)
        {
            ConsoleUtilities.WriteLine("You feel a draft. There is a pit in a nearby room.", ConsoleColor.Magenta);
        }
    }

    public class MaelstromWindSense : ISense
    {
        public bool CanSense(Game game)
        {
            foreach (Monster monster in game.Map.Monsters)
            {
                if (monster is Maelstrom && monster.IsAlive)
                {
                    if (game.IsEnemyNearby(monster.Location))
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        public void DisplaySense(Game game)
        {
            ConsoleUtilities.WriteLine("You hear the growling and \r\ngroaning of a maelstrom nearby.", ConsoleColor.Magenta);
        }
    }

    public class AmarokSmellSense : ISense
    {
        public bool CanSense(Game game)
        {
            foreach (Monster monster in game.Map.Monsters)
            {
                if (monster is Amarok && monster.IsAlive)
                {
                    if (game.IsEnemyNearby(monster.Location))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public void DisplaySense(Game game)
        {
            ConsoleUtilities.WriteLine("You can smell the rotten stench of an amarok in a nearby room.", ConsoleColor.Magenta);
        }
    }
}
