using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;
using System.Collections.Generic;

namespace PoliziaMunicipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneDAO _tipoViolazioneDAO;

        public TipoViolazioneController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _tipoViolazioneDAO = new TipoViolazioneDAO(connectionString);
        }

        public IActionResult Index()
        {
            IEnumerable<TipoViolazione> tipoViolazioni = _tipoViolazioneDAO.GetAll();
            return View(tipoViolazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                _tipoViolazioneDAO.Add(tipoViolazione);
                return RedirectToAction("Index");
            }
            return View(tipoViolazione);
        }

        public IActionResult Edit(int id)
        {
            var tipoViolazione = _tipoViolazioneDAO.GetById(id);
            if (tipoViolazione == null)
            {
                return NotFound();
            }
            return View(tipoViolazione);
        }

        [HttpPost]
        public IActionResult Edit(TipoViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                _tipoViolazioneDAO.Update(tipoViolazione);
                return RedirectToAction("Index");
            }
            return View(tipoViolazione);
        }

        public IActionResult Delete(int id)
        {
            var tipoViolazione = _tipoViolazioneDAO.GetById(id);
            if (tipoViolazione == null)
            {
                return NotFound();
            }
            return View(tipoViolazione);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _tipoViolazioneDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
