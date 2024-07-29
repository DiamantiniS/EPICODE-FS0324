using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hotel.DAO;
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
                _logger.LogInformation("Inizio ricerca prenotazioni per codice fiscale: {CodiceFiscale}", codiceFiscale);

                var prenotazioni = _prenotazioneDao.GetPrenotazioniByCodiceFiscale(codiceFiscale);

                if (prenotazioni == null || !prenotazioni.Any())
                {
                    _logger.LogWarning("Nessuna prenotazione trovata per il codice fiscale: {CodiceFiscale}", codiceFiscale);
                    return NotFound("Nessuna prenotazione trovata per il codice fiscale specificato.");
                }

                _logger.LogInformation("Trovate {Count} prenotazioni per il codice fiscale: {CodiceFiscale}", prenotazioni.Count(), codiceFiscale);

                return PartialView("~/Views/Admin/Prenotazioni/_PrenotazioniListPartial.cshtml", prenotazioni);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la ricerca delle prenotazioni per il codice fiscale: {CodiceFiscale}", codiceFiscale);
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
