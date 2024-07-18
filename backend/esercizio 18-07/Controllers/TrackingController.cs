using Microsoft.AspNetCore.Mvc;
using esercizio_18_07.Data;
using System.Linq;

namespace esercizio_18_07.Controllers
{
    public class TrackingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrackingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TrackShipment(string fiscalCodeOrVat, string trackingNumber)
        {
            var client = _context.Clients.FirstOrDefault(c =>
                c.FiscalCode == fiscalCodeOrVat || c.VatNumber == fiscalCodeOrVat);

            if (client == null)
            {
                ModelState.AddModelError("", "Client not found");
                return View("Index");
            }

            var shipment = _context.Shipments.FirstOrDefault(s =>
                s.ClientId == client.ClientId && s.TrackingNumber == trackingNumber);

            if (shipment == null)
            {
                ModelState.AddModelError("", "Shipment not found");
                return View("Index");
            }

            var updates = _context.ShipmentUpdates
                                  .Where(u => u.ShipmentId == shipment.ShipmentId)
                                  .OrderByDescending(u => u.UpdateDate)
                                  .ToList();

            return View("ShipmentUpdates", updates);
        }
    }
}
