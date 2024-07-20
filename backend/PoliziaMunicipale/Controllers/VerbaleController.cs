using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;
using System.Linq;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleDAO _dao;
        private readonly AnagraficaDAO _anagraficaDAO;  // Aggiungi l'AnagraficaDAO

        public VerbaleController(VerbaleDAO dao, AnagraficaDAO anagraficaDAO)  // Includi l'AnagraficaDAO nel costruttore
        {
            _dao = dao;
            _anagraficaDAO = anagraficaDAO;
        }

        public IActionResult Index()
        {
            var model = _dao.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _dao.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Verbale model)
        {
            if (ModelState.IsValid)
            {
                
                var anagrafica = _dao.GetAnagraficaByNomeCognome(model.Anagrafica.Nome, model.Anagrafica.Cognome);
                if (anagrafica == null)
                {
                    ModelState.AddModelError(string.Empty, "Anagrafica non trovata. Verifica Nome e Cognome.");
                    return View(model);
                }

                model.AnagraficaId = anagrafica.Id;
                _dao.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var model = _dao.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, Verbale model, string nome, string cognome)
        {
            var anagrafica = _anagraficaDAO.GetByNomeCognome(nome, cognome);

            if (anagrafica == null)
            {
                ModelState.AddModelError(string.Empty, "Nome o Cognome non trovati.");
            }
            else
            {
                model.AnagraficaId = anagrafica.Id;

                if (ModelState.IsValid)
                {
                    _dao.Update(id, model);
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = _dao.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _dao.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ViolazioniOver400Euro()
        {
            var verbali = _dao.GetViolazioniOver400Euro();
            var model = verbali.Select(v => (v.Anagrafica?.Nome, v.Anagrafica?.Cognome, v.Importo, v.DataViolazione, v.DecurtamentoPunti, v.Id)).ToList();
            return View(model);
        }

        public IActionResult ViolazioniOverTenPoints()
        {
            var verbali = _dao.GetViolazioniOverTenPoints();
            var model = verbali.Select(v => (v.Anagrafica?.Nome, v.Anagrafica?.Cognome, v.Importo, v.DataViolazione, v.DecurtamentoPunti, v.Id)).ToList();
            return View(model);
        }

        public IActionResult PuntiDecurtatiTrasgressori()
        {
            var verbali = _dao.GetPuntiDecurtatiTrasgressori();
            var model = verbali.Select(v => (v.Anagrafica?.Nome, v.Anagrafica?.Cognome, v.DecurtamentoPunti, v.Id)).ToList();
            return View(model);
        }

        public IActionResult VerbaliTrasgressori()
        {
            var verbali = _dao.GetVerbaliTrasgressori();
            var model = verbali.Select(v => (v.Anagrafica?.Nome, v.Anagrafica?.Cognome, v.Importo, v.DataViolazione, v.DecurtamentoPunti, v.Id)).ToList();
            return View(model);
        }

        public IActionResult TotalePuntiDecurtatiPerTrasgressore()
        {
            var result = _dao.GetTotalePuntiDecurtatiPerTrasgressore();
            var model = result.Select(r => (r.Cognome, r.Nome, r.TotalePunti, r.Id)).ToList(); // Assicurati che la tupla abbia il giusto numero di elementi
            return View(model);
        }
    }
}
