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

        public void DisplayStartMessages()
        {
            ConsoleUtilities.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search" +
                " of the Fountain of Objects. Light is visible only in the entrance, and no other light is seen anywhere in the caverns.\r\n" +
                "You must navigate the Caverns with your other senses. Find the Fountain of Objects, activate it, and return to the entrance.\n", ConsoleColor.Green);
            ConsoleUtilities.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.\n", ConsoleColor.DarkMagenta);
            ConsoleUtilities.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location " +
                "in the caverns. You will be able to hear their growling and groaning in nearby rooms.\n", ConsoleColor.DarkMagenta);
            ConsoleUtilities.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.\n", ConsoleColor.DarkMagenta);
            ConsoleUtilities.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply\n", ConsoleColor.DarkMagenta);
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
                if (command == "help") return new HelpCommand();

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
