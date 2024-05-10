using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public class Game
    {
        public Player Player { get; }
        public Map Map { get; }
        public bool IsFountainActive { get; set; } = false;
        public ISense[] Senses { get; set; }

        public Game(Player player, Map map)
        {
            Player = player;
            Map = map;
            Senses =
            [
                new FountainSense(),
                new PitBreezeSense(),
                new ExitSense(),
                new MaelstromWindSense(),
                new AmarokSmellSense()
            ];


        }

        public void Run()
        {
            while (!HasWon && Player.PlayerAlive)
            {
                DisplayStatus();
                ICommand command = GetCommand();
                command.Execute(this);

                if (CurrentRoom == RoomType.Pit)
                {
                    Player.Kill("You fell into a pit....");
                }

                foreach (Monster m in Map.Monsters)
                {
                    if (m.Location == Player.Location && m.IsAlive == true)
                    {
                        m.Activate(this);
                    }
                }
            }

            if (HasWon)
            {
                ConsoleUtilities.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.Green);
                ConsoleUtilities.WriteLine("You Win!", ConsoleColor.White);

            }

        }

        public void DisplayStatus()
        {
            ConsoleUtilities.WriteLine("-------------------------------------------------------------", ConsoleColor.Green);
            ConsoleUtilities.WriteLine($"You are in the room at Row: {Player.Location.Row}, Column: {Player.Location.Column}", ConsoleColor.Green);
            foreach (ISense sense in Senses)
            {
                if (sense.CanSense(this))
                    sense.DisplaySense(this);
            }

        }

        public ICommand GetCommand()
        {
            while (true)
            {

                ConsoleUtilities.WriteLine("What do you want to do? ", ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? command = Console.ReadLine();

                if (command == "move north") return new MoveCommand(Direction.North);
                if (command == "move east") return new MoveCommand(Direction.East);
                if (command == "move south") return new MoveCommand(Direction.South);
                if (command == "move west") return new MoveCommand(Direction.West);
                if (command == "activate fountain") return new EnableFountainCommand();
                if (command == "shoot north") return new AttackCommand(Direction.North);
                if (command == "shoot east") return new AttackCommand(Direction.East);
                if (command == "shoot south") return new AttackCommand(Direction.South);
                if (command == "shoot west") return new AttackCommand(Direction.West);

                ConsoleUtilities.WriteLine($"I did not understand {command}, please try again.", ConsoleColor.Red);

            }
        }

        public bool CheckAdjacentRoomsForRoomType(Location refLocation, RoomType roomType)
        {
            if (Map.IsOnMap(new Location(refLocation.Row - 1, refLocation.Column - 1)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row - 1, refLocation.Column - 1)) == roomType) return true;

            if (Map.IsOnMap(new Location(refLocation.Row - 1, refLocation.Column)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row - 1, refLocation.Column)) == roomType) return true;

            if (Map.IsOnMap(new Location(refLocation.Row - 1, refLocation.Column + 1)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row - 1, refLocation.Column + 1)) == roomType) return true;

            if (Map.IsOnMap(new Location(refLocation.Row, refLocation.Column - 1)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row, refLocation.Column - 1)) == roomType) return true;

            if (Map.IsOnMap(new Location(refLocation.Row, refLocation.Column + 1)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row, refLocation.Column + 1)) == roomType) return true;

            if (Map.IsOnMap(new Location(refLocation.Row + 1, refLocation.Column - 1)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row + 1, refLocation.Column - 1)) == roomType) return true;

            if (Map.IsOnMap(new Location(refLocation.Row + 1, refLocation.Column)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row + 1, refLocation.Column)) == roomType) return true;

            if (Map.IsOnMap(new Location(refLocation.Row + 1, refLocation.Column + 1)) &&
                Map.GetLocationRoomType(new Location(refLocation.Row + 1, refLocation.Column + 1)) == roomType) return true;
            return false;
        }

        public bool IsEnemyNearby(Location enemyLocation)
        {
            return Math.Abs(Player.Location.Row - enemyLocation.Row) <= 1 && Math.Abs(Player.Location.Column - enemyLocation.Column) <= 1;
        }
        public bool HasWon => IsFountainActive && CurrentRoom == RoomType.Exit && Player.PlayerAlive;

        public RoomType CurrentRoom => Map.GetRoomTypeAtLocation(Player.Location);


    }
}
