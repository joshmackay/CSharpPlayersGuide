using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public class Player
    {
        public Location Location { get; set; }
        public bool PlayerAlive { get; set; } = true;

        public Player(Location start)
        {
            Location = start;
        }

        public void Kill(string message)
        {
            PlayerAlive = false;
            ConsoleUtilities.WriteLine(message, ConsoleColor.Red);
            ConsoleUtilities.WriteLine("You died. GAME OVER!", ConsoleColor.Red);
        }

    }
}
