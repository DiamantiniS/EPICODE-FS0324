using CinemaTicketSystem.Identiti;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketSystem.Services
{
    public class CinemaService
    {
        private static List<Cinema> _cinemas = new List<Cinema>
        {
            new Cinema { Nome = "SALA NORD" },
            new Cinema { Nome = "SALA EST" },
            new Cinema { Nome = "SALA SUD" }
        };

        public List<Cinema> GetCinemas()
        {
            return _cinemas;
        }

        public void AddTicket(Ticket ticket)
        {
            var cinema = _cinemas.FirstOrDefault(c => c.Nome == ticket.Sala);
            if (cinema != null && cinema.BigliettiVenduti < cinema.CapacitaMassima)
            {
                cinema.Biglietti.Add(ticket);
                cinema.BigliettiVenduti++;
                if (ticket.TipoBiglietto == "Ridotto")
                {
                    cinema.BigliettiRidottiVenduti++;
                }
            }
        }
    }
}
