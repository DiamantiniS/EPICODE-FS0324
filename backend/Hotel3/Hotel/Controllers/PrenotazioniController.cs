using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hotel.DAO;
using Hotel.Models;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;

namespace Hotel.Controllers
{
    [Authorize(Policy = "GeneralAccessPolicy")]
    public class PrenotazioniController : Controller
    {
        private readonly IPrenotazioneDao _prenotazioneDao;
        private readonly IClienteDao _clienteDao;
        private readonly ICameraDao _cameraDao;
        private readonly IServizioDao _servizioDao;

        public PrenotazioniController(IPrenotazioneDao prenotazioneDao, IClienteDao clienteDao, ICameraDao cameraDao, IServizioDao servizioDao)
        {
            _prenotazioneDao = prenotazioneDao;
            _clienteDao = clienteDao;
            _cameraDao = cameraDao;
            _servizioDao = servizioDao;
        }

        public IActionResult Index()
        {
            var prenotazioni = _prenotazioneDao.GetAll();
            return View("~/Views/Admin/Prenotazioni/Index.cshtml", prenotazioni);
        }

        public IActionResult Details(int id)
        {
            var prenotazione = _prenotazioneDao.GetById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            prenotazione.Servizi = _servizioDao.GetByPrenotazioneId(id).ToList();
            return PartialView("~/Views/Admin/Prenotazioni/_DetailsPartial.cshtml", prenotazione);
        }

        public IActionResult Create()
        {
            ViewBag.Clienti = _clienteDao.GetAll();
            ViewBag.Camere = _cameraDao.GetAll();
            ViewBag.Servizi = _servizioDao.GetAll();

            var prenotazione = new Prenotazione
            {
                Anno = 2024,
                NumeroProgressivo = _prenotazioneDao.GetLastId() + 1
            };

            return PartialView("~/Views/Admin/Prenotazioni/_CreatePartial.cshtml", prenotazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                _prenotazioneDao.Add(prenotazione);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clienti = _clienteDao.GetAll();
            ViewBag.Camere = _cameraDao.GetAll();
            ViewBag.Servizi = _servizioDao.GetAll();
            return PartialView("~/Views/Admin/Prenotazioni/_CreatePartial.cshtml", prenotazione);
        }

        public IActionResult Edit(int id)
        {
            var prenotazione = _prenotazioneDao.GetById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            prenotazione.ServiziSelezionati = _servizioDao.GetByPrenotazioneId(id).Select(s => s.Id).ToList();

            ViewBag.Clienti = _clienteDao.GetAll();
            ViewBag.Camere = _cameraDao.GetAll();
            ViewBag.Servizi = _servizioDao.GetAll();
            return PartialView("~/Views/Admin/Prenotazioni/_EditPartial.cshtml", prenotazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Prenotazione prenotazione)
        {
            if (id != prenotazione.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _prenotazioneDao.Update(prenotazione);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clienti = _clienteDao.GetAll();
            ViewBag.Camere = _cameraDao.GetAll();
            ViewBag.Servizi = _servizioDao.GetAll();
            return PartialView("~/Views/Admin/Prenotazioni/_EditPartial.cshtml", prenotazione);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _prenotazioneDao.Delete(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetCameraPrice(int id)
        {
            var camera = _cameraDao.GetById(id);
            if (camera == null)
            {
                return NotFound();
            }
            return Json(camera.Prezzo);
        }

        [HttpGet]
        public IActionResult CheckoutPartial(int id)
        {
            var prenotazione = _prenotazioneDao.GetById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            prenotazione.Servizi = _servizioDao.GetByPrenotazioneId(id).ToList();

            var giorniSoggiorno = (prenotazione.Al - prenotazione.Dal).Days;
            var totaleStanza = prenotazione.Tariffa * giorniSoggiorno;
            decimal extraSoggiorno = 0;

            switch (prenotazione.TipologiaSoggiorno.ToLower())
            {
                case "mezza pensione":
                    extraSoggiorno = 10 * giorniSoggiorno;
                    break;
                case "pensione completa":
                    extraSoggiorno = 20 * giorniSoggiorno;
                    break;
                case "pernottamento con prima colazione":
                    extraSoggiorno = 5 * giorniSoggiorno;
                    break;
            }

            var totaleServizi = prenotazione.Servizi.Sum(s => s.Prezzo);
            var totale = totaleStanza + totaleServizi + extraSoggiorno - prenotazione.Caparra;

            var viewModel = new CheckoutViewModel
            {
                Prenotazione = prenotazione,
                TotaleStanza = totaleStanza,
                TotaleServizi = totaleServizi,
                ExtraSoggiorno = extraSoggiorno,
                Totale = totale
            };

            return PartialView("~/Views/Admin/Prenotazioni/_CheckoutPartial.cshtml", viewModel);
        }


        public IActionResult DownloadPdf(int id)
        {
            var prenotazione = _prenotazioneDao.GetById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            prenotazione.Servizi = _servizioDao.GetByPrenotazioneId(id).ToList();

            var giorniSoggiorno = (prenotazione.Al - prenotazione.Dal).Days;
            var totaleStanza = prenotazione.Tariffa * giorniSoggiorno;
            decimal extraSoggiorno = 0;

            switch (prenotazione.TipologiaSoggiorno.ToLower())
            {
                case "mezza pensione":
                    extraSoggiorno = 10 * giorniSoggiorno;
                    break;
                case "pensione completa":
                    extraSoggiorno = 20 * giorniSoggiorno;
                    break;
                case "pernottamento con prima colazione":
                    extraSoggiorno = 5 * giorniSoggiorno;
                    break;
            }

            var totaleServizi = prenotazione.Servizi.Sum(s => s.Prezzo);
            var totale = totaleStanza + totaleServizi + extraSoggiorno - prenotazione.Caparra;

            var checkoutViewModel = new CheckoutViewModel
            {
                Prenotazione = prenotazione,
                TotaleStanza = totaleStanza,
                TotaleServizi = totaleServizi,
                ExtraSoggiorno = extraSoggiorno,
                Totale = totale
            };

            using (var ms = new MemoryStream())
            {
                var document = new Document();
                PdfWriter.GetInstance(document, ms);
                document.Open();

                document.Add(new Paragraph("Riepilogo Check-out"));
                document.Add(new Paragraph($"Cliente: {checkoutViewModel.Prenotazione.Cliente.Cognome} {checkoutViewModel.Prenotazione.Cliente.Nome}"));
                document.Add(new Paragraph($"Camera: {checkoutViewModel.Prenotazione.Camera.Descrizione}"));
                document.Add(new Paragraph($"Dal: {checkoutViewModel.Prenotazione.Dal.ToShortDateString()}"));
                document.Add(new Paragraph($"Al: {checkoutViewModel.Prenotazione.Al.ToShortDateString()}"));
                document.Add(new Paragraph($"Tariffa giornaliera: {checkoutViewModel.Prenotazione.Tariffa.ToString("C")}"));
                document.Add(new Paragraph($"Caparra: {checkoutViewModel.Prenotazione.Caparra.ToString("C")}"));
                document.Add(new Paragraph($"Tipologia Soggiorno: {checkoutViewModel.Prenotazione.TipologiaSoggiorno}"));

                document.Add(new Paragraph("Servizi Aggiuntivi:"));
                foreach (var servizio in checkoutViewModel.Prenotazione.Servizi)
                {
                    document.Add(new Paragraph($"{servizio.Descrizione} - {servizio.Prezzo.ToString("C")}"));
                }

                document.Add(new Paragraph($"Totale Stanza: {checkoutViewModel.TotaleStanza.ToString("C")}"));
                document.Add(new Paragraph($"Totale Servizi Aggiuntivi: {checkoutViewModel.TotaleServizi.ToString("C")}"));
                document.Add(new Paragraph($"Extra Soggiorno ({checkoutViewModel.Prenotazione.TipologiaSoggiorno}): {checkoutViewModel.ExtraSoggiorno.ToString("C")}"));
                document.Add(new Paragraph($"Caparra Iniziale: {checkoutViewModel.Prenotazione.Caparra.ToString("C")}"));
                document.Add(new Paragraph($"Totale Da Saldare: {checkoutViewModel.Totale.ToString("C")}"));

                document.Close();

                return File(ms.ToArray(), "application/pdf", "Riepilogo_Checkout.pdf");
            }
        }
    }
}
