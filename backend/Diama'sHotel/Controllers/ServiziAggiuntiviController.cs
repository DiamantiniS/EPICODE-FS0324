using Microsoft.AspNetCore.Mvc;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Controllers
{
    public class ServiziAggiuntiviController : Controller
    {
        private readonly IServizioAggiuntivoService _servizioAggiuntivoService;

        public ServiziAggiuntiviController(IServizioAggiuntivoService servizioAggiuntivoService)
        {
            _servizioAggiuntivoService = servizioAggiuntivoService;
        }

        public async Task<IActionResult> Index()
        {
            var servizi = await _servizioAggiuntivoService.GetAllServiziAggiuntiviAsync();
            return View(servizi);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServizioAggiuntivo servizio)
        {
            if (ModelState.IsValid)
            {
                await _servizioAggiuntivoService.AddServizioAggiuntivoAsync(servizio);
                return RedirectToAction(nameof(Index));
            }
            return View(servizio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var servizio = await _servizioAggiuntivoService.GetServizioAggiuntivoByIdAsync(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return View(servizio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServizioAggiuntivo servizio)
        {
            if (id != servizio.IDServizio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _servizioAggiuntivoService.UpdateServizioAggiuntivoAsync(servizio);
                return RedirectToAction(nameof(Index));
            }
            return View(servizio);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var servizio = await _servizioAggiuntivoService.GetServizioAggiuntivoByIdAsync(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return View(servizio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _servizioAggiuntivoService.DeleteServizioAggiuntivoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
