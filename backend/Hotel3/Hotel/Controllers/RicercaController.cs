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
        private readonly ILogger<RicercaController> _logger;

        public RicercaController(IPrenotazioneDao prenotazioneDao, ILogger<RicercaController> logger)
        {
            _prenotazioneDao = prenotazioneDao;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/admin/ricerca/index.cshtml");
        }

        [HttpPost]
        public IActionResult RicercaPrenotazioniCliente(string codiceFiscale)
        {
            try
            {
                var prenotazioni = _prenotazioneDao.GetPrenotazioniByCodiceFiscale(codiceFiscale);
                if (prenotazioni == null)
                {
                    return NotFound("Nessuna prenotazione trovata per il codice fiscale specificato.");
                }
                return PartialView("_PrenotazioniListPartial", prenotazioni);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la ricerca delle prenotazioni per il codice fiscale {CodiceFiscale}", codiceFiscale);
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta.");
            }
        }

        [HttpPost]
        public IActionResult RicercaNumeroPrenotazioniPensioneCompleta()
        {
            try
            {
                var totalePrenotazioni = _prenotazioneDao.GetTotalePrenotazioniPerTipologia("pensione completa");
                return Content($"Totale prenotazioni per soggiorni di tipo \"pensione completa\": {totalePrenotazioni}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la ricerca del numero di prenotazioni per pensione completa.");
                return StatusCode(500, "Si è verificato un errore durante l'elaborazione della richiesta.");
            }
        }
    }
}
