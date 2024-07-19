using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Models;
using PoliziaMunicipale.Data;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleDAO _dao;

        public VerbaleController(VerbaleDAO dao)
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

        [HttpPost]
        public IActionResult Create(Verbale model)
        {
            if (ModelState.IsValid)
            {
                _dao.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, Verbale model)
        {
            if (ModelState.IsValid)
            {
                _dao.Update(id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
