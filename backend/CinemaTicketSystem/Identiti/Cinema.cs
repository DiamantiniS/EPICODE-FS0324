using System.Collections.Generic;

namespace CinemaTicketSystem.Identiti
{
    public class Cinema
    {
        public string Nome { get; set; }
        public int CapacitaMassima { get; set; } = 2;
        public int BigliettiVenduti { get; set; }
        public int BigliettiRidottiVenduti { get; set; }

        public List<Ticket> Biglietti { get; set; } = new List<Ticket>();
    }
}