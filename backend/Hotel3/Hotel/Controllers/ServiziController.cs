using Hotel.Models;
using Hotel.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class ServiziController : Controller
    {
        private readonly IServizioDao _servizioDao;

        public ServiziController(IServizioDao servizioDao)
        {
            _servizioDao = servizioDao;
        }

        public IActionResult Index()
        {
            try
            {
                var servizi = _servizioDao.GetAll();
                return View("~/Views/Admin/Servizi/Index.cshtml", servizi);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Details(int id)
        {
            var servizio = _servizioDao.GetById(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Admin/Servizi/_DetailsPartial.cshtml", servizio);
        }

        public IActionResult Create()
        {
            return PartialView("~/Views/Admin/Servizi/_CreatePartial.cshtml", new Servizio());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Servizio servizio)
        {
            if (ModelState.IsValid)
            {
                _servizioDao.Add(servizio);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("~/Views/Admin/Servizi/_CreatePartial.cshtml", servizio);
        }

        public IActionResult Edit(int id)
        {
            var servizio = _servizioDao.GetById(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Admin/Servizi/_EditPartial.cshtml", servizio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Servizio servizio)
        {
            if (id != servizio.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _servizioDao.Update(servizio);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("~/Views/Admin/Servizi/_EditPartial.cshtml", servizio);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _servizioDao.Delete(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
