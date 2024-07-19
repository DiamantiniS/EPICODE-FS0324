using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaDAO _dao;

        public AnagraficaController(AnagraficaDAO dao)
        {
            _dao = dao;
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
        public IActionResult Create(Anagrafica model)
        {
            if (ModelState.IsValid)
            {
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
        public IActionResult Edit(int id, Anagrafica model)
        {
            if (ModelState.IsValid)
            {
                _dao.Update(id, model);
                return RedirectToAction("Index");
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
    }
}
