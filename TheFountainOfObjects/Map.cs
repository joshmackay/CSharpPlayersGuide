using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public class Map
    {
        private Random Random = new Random();
        private List<RoomDetails> _roomsList;
        public int MapRows { get; }
        public int MapCols { get; }
        public List<Monster> Monsters { get; set; } = new List<Monster>();


        public Map(int rows, int columns, int totalPits, int totalMaelstroms, int totalAmaroks)
        {
            MapRows = rows;
            MapCols = columns;
            _roomsList = new List<RoomDetails>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _roomsList.Add(new RoomDetails(RoomType.Normal, new Location(i, j)));
                }
            }

            SetRoomTypeAtLocation(RoomType.Exit, new Location(0, 0));
            SetRoomTypeAtLocation(RoomType.Fountain, GetRandomEmptyLocation());
            GeneratePits(totalPits);

            for (int i = 0; i < totalMaelstroms; i++)
            {
                Monsters.Add(new Maelstrom(PlaceMonster()));
            }

            for (int i = 0; i < totalAmaroks; i++)
            {
                Monsters.Add(new Amarok(GetRandomEmptyLocation()));
            }
        }

        public RoomType GetRoomTypeAtLocation(Location location)
        {
            return _roomsList.FirstOrDefault(d => d.location == location).roomType;
        }

        public Location GetRandomEmptyLocation()
        {
            var emptyRooms = GetEmptyRoomLocations();
            var randNum = Random.Next(emptyRooms.Count);
            return emptyRooms.ElementAt(randNum).location;
        }

        public List<RoomDetails> GetEmptyRoomLocations()
        {
            return _roomsList.Where(detail => detail.roomType == RoomType.Normal).ToList();
        }

        public void SetRoomTypeAtLocation(RoomType type, Location location)
        {
            _roomsList.FirstOrDefault(d => d.location == location).roomType = type;
        }

        public Location PlaceMonster()
        {
            var availableLocations = GetEmptyRoomLocations().Where(room => Monsters.All(monster => monster.Location != room.location)).ToList();
            var randRoom = availableLocations.ElementAt(Random.Next(availableLocations.Count));
            return randRoom.location;
        }

        public void GeneratePits(int totalPits)
        {
            for (var i = 0; i < totalPits; i++)
            {
                Location newPitLocation = GetRandomEmptyLocation();
                SetRoomTypeAtLocation(RoomType.Pit, newPitLocation);
            }
        }

        public RoomType GetCurrentRoomType(Player player)
        {
            return _roomsList.FirstOrDefault(d => d.location == player.Location).roomType;
        }

        public RoomType GetLocationRoomType(Location location)
        {
            return _roomsList.FirstOrDefault(d => d.location == location).roomType;
        }

        public bool IsOnMap(Location location)
        {
            return
                location.Row >= 0 &&
                location.Row < MapRows &&
                location.Column >= 0 &&
                location.Column < MapCols;
        }
    }
}
