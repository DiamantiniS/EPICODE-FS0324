using System.Collections.Generic;

namespace CinemaMVC.Models
{
    public class Room
    {
        public string Name { get; set; }
        public int TotalTickets { get; set; }
        public int ReducedTickets { get; set; }
        public int Capacity { get; set; } = 120;
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
