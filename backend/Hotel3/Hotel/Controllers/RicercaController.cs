using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hotel.DAO;
using Hotel.Models;
using Microsoft.Extensions.Logging;


namespace Hotel.Controllers
{
    [Authorize(Policy = "GeneralAccessPolicy")]

    public class RicercaController : Controller
    {
        private readonly IPrenotazioneDao _prenotazioneDao;

        public RicercaController(IPrenotazioneDao prenotazioneDao)
        {
            _prenotazioneDao = prenotazioneDao;
        }

        public IActionResult Index()
        {
            return View("~/Views/admin/ricerca/index.cshtml");
        }

        [HttpPost]
        public IActionResult RicercaPrenotazioniCliente(string codiceFiscale)
        {
            var prenotazioni = _prenotazioneDao.GetPrenotazioniByCodiceFiscale(codiceFiscale);
            return PartialView("~/Views/Admin/Ricerca/_PrenotazioniListPartial.cshtml", prenotazioni);
        }

        [HttpPost]
        public IActionResult RicercaNumeroPrenotazioniPensioneCompleta()
        {
            var totalePrenotazioni = _prenotazioneDao.GetTotalePrenotazioniPerTipologia("pensione completa");
            return Content($"Totale prenotazioni per soggiorni di tipo \"pensione completa\": {totalePrenotazioni}");
        }
    }
}
