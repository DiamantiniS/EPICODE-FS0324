using Microsoft.AspNetCore.Mvc;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Controllers
{
    public class PrenotazioniController : Controller
    {
        private readonly IPrenotazioneService _prenotazioneService;

        public PrenotazioniController(IPrenotazioneService prenotazioneService)
        {
            _prenotazioneService = prenotazioneService;
        }

        public async Task<IActionResult> Index()
        {
            var prenotazioni = await _prenotazioneService.GetAllPrenotazioniAsync();
            return View(prenotazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                await _prenotazioneService.AddPrenotazioneAsync(prenotazione);
                return RedirectToAction(nameof(Index));
            }
            return View(prenotazione);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var prenotazione = await _prenotazioneService.GetPrenotazioneByIdAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            return View(prenotazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prenotazione prenotazione)
        {
            if (id != prenotazione.IDPrenotazione)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _prenotazioneService.UpdatePrenotazioneAsync(prenotazione);
                return RedirectToAction(nameof(Index));
            }
            return View(prenotazione);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var prenotazione = await _prenotazioneService.GetPrenotazioneByIdAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            return View(prenotazione);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _prenotazioneService.DeletePrenotazioneAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
