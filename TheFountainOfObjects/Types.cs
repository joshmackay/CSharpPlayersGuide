using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public enum RoomType
    {
        Normal,
        Fountain,
        Exit,
        Pit,
        OffMap
    }

    public record Location(int Row, int Column);

    public class RoomDetails
    {
        public RoomType roomType;
        public Location location;

        public RoomDetails(RoomType roomType, Location location)
        {
            this.roomType = roomType;
            this.location = location;
        }
    }
}
