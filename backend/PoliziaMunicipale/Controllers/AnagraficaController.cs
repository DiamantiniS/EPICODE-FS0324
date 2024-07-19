using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;
using System.Collections.Generic;

namespace PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaDAO _anagraficaDAO;

        public AnagraficaController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _anagraficaDAO = new AnagraficaDAO(connectionString);
        }

        public IActionResult Index()
        {
            IEnumerable<Anagrafica> anagrafiche = _anagraficaDAO.GetAll();
            return View(anagrafiche);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _anagraficaDAO.Add(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }

        public IActionResult Edit(int id)
        {
            var anagrafica = _anagraficaDAO.GetById(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        [HttpPost]
        public IActionResult Edit(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _anagraficaDAO.Update(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }

        public IActionResult Delete(int id)
        {
            var anagrafica = _anagraficaDAO.GetById(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _anagraficaDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
