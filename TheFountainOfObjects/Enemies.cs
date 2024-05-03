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

        }

    }
}
