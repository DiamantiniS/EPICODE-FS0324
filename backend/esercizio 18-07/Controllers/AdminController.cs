using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using esercizio_18_07.Data;
using esercizio_18_07.Models;
using System.Linq;

namespace esercizio_18_07.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clients()
        {
            var clients = _context.Clients.ToList();
            return View(clients);
        }

        [HttpPost]
        public IActionResult AddClient(Client model)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Clients");
            }
            return View(model);
        }

        public IActionResult Shipments()
        {
            var shipments = _context.Shipments.ToList();
            return View(shipments);
        }

        [HttpPost]
        public IActionResult AddShipment(Shipment model)
        {
            if (ModelState.IsValid)
            {
                _context.Shipments.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Shipments");
            }
            return View(model);
        }

        public IActionResult ShipmentUpdates(int shipmentId)
        {
            var updates = _context.ShipmentUpdates
                                  .Where(s => s.ShipmentId == shipmentId)
                                  .OrderByDescending(s => s.UpdateDate)
                                  .ToList();
            return View(updates);
        }

        [HttpPost]
        public IActionResult AddShipmentUpdate(ShipmentUpdate model)
        {
            if (ModelState.IsValid)
            {
                _context.ShipmentUpdates.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ShipmentUpdates", new { shipmentId = model.ShipmentId });
            }
            return View(model);
        }
    }
}
