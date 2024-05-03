using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public class Map
    {
        private readonly RoomType[,] _rooms;
        public int MapRows { get; }
        public int MapCols { get; }

        public Map(int rows, int columns, int totalPits, int totalMaelstroms)
        {
            MapRows = rows;
            MapCols = columns;
            _rooms = new RoomType[rows, columns];

            SetRoomTypeAtLocation(RoomType.Exit, new Location(0, 0));
            SetRoomTypeAtLocation(RoomType.Fountain, GetRandomEmptyLocation());
            GeneratePits(totalPits);
        }

        public RoomType GetRoomTypeAtLocation(Location location)
        {
            return _rooms[location.Row, location.Column];
        }

        public Location GetRandomEmptyLocation()
        {
            List<Location> locations = GetEmptyRoomLocations();
            return locations.ElementAt(new Random().Next(0, locations.Count - 1));
        }

        public List<Location> GetEmptyRoomLocations()
        {
            List<Location> locations = new List<Location>();
            for (int i = 0; i < _rooms.GetLength(0); i++)
            {
                for (int j = 0; j < _rooms.GetLength(1); j++)
                {
                    if (_rooms[i, j] == RoomType.Normal) locations.Add(new Location(i, j));
                }
            }
            return locations;
        }

        public void SetRoomTypeAtLocation(RoomType type, Location location)
        {
            _rooms[location.Row, location.Column] = type;
        }


        public void GeneratePits(int totalPits)
        {
            for (var i = 0; i < totalPits; i++)
            {
                Location newPitLocation = GetRandomEmptyLocation();
                SetRoomTypeAtLocation(RoomType.Pit, newPitLocation);
            }
        }

        public bool IsLocationTaken(Location location)
        {
            return _rooms[location.Row, location.Column] != null ? true : false;
        }

        public RoomType GetCurrentRoomType(Player player)
        {
            return _rooms[player.Location.Row, player.Location.Column];
        }

        public RoomType GetLocationRoomType(Location location)
        {
            return _rooms[location.Row, location.Column];
        }

        public bool IsOnMap(Location location)
        {
            return
                location.Row >= 0 &&
                location.Row < _rooms.GetLength(0) &&
                location.Column >= 0 &&
                location.Column < _rooms.GetLength(1);
        }
    }
}
