using CinemaTicketSystem.Identiti;
using CinemaTicketSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaTicketSystem.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public IActionResult Index()
        {
            var cinemas = _cinemaService.GetCinemas();
            return View(cinemas);
        }

        public IActionResult SellTicket()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SellTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _cinemaService.AddTicket(ticket);
                return RedirectToAction("Index");
            }
            return View(ticket);
        }
    }
}
