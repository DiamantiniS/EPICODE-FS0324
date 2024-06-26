using System.Collections.Generic;

namespace CinemaMVC.Models
{
    public static class StaticData
    {
        public static List<Room> Rooms = new List<Room>
        {
            new Room { Name = "SALA NORD" },
            new Room { Name = "SALA EST" },
            new Room { Name = "SALA SUD" }
        };
    }
}

