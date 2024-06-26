using CinemaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaMVC.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View(StaticData.Rooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var room = StaticData.Rooms.FirstOrDefault(r => r.Name == ticket.Room);
                if (room != null && room.TotalTickets < room.Capacity)
                {
                    room.Tickets.Add(ticket);
                    room.TotalTickets++;
                    if (ticket.IsReduced)
                    {
                        room.ReducedTickets++;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ticket);
        }
    }
}