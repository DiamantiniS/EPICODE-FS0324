using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneDAO _dao;

        public TipoViolazioneController(TipoViolazioneDAO dao)
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
        public IActionResult Create(TipoViolazione model)
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
        public IActionResult Edit(int id, TipoViolazione model)
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
