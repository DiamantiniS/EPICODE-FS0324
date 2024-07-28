using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hotel.DAO;

namespace Hotel.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class CamereController : Controller
    {
        private readonly ICameraDao _cameraDao;

        public CamereController(ICameraDao cameraDao)
        {
            _cameraDao = cameraDao;
        }

        public IActionResult Index()
        {
            var camere = _cameraDao.GetAll();
            return View("~/Views/Admin/Camere/Index.cshtml", camere);
        }

        public IActionResult Details(int id)
        {
            var camera = _cameraDao.GetById(id);
            if (camera == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Admin/Camere/_DetailsPartial.cshtml", camera);
        }

        public IActionResult Create()
        {
            return PartialView("~/Views/Admin/Camere/_CreatePartial.cshtml", new Camera());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Camera camera)
        {
            if (ModelState.IsValid)
            {
                _cameraDao.Add(camera);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("~/Views/Admin/Camere/_CreatePartial.cshtml", camera);
        }

        public IActionResult Edit(int id)
        {
            var camera = _cameraDao.GetById(id);
            if (camera == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Admin/Camere/_EditPartial.cshtml", camera);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Camera camera)
        {
            if (id != camera.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _cameraDao.Update(camera);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("~/Views/Admin/Camere/_EditPartial.cshtml", camera);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _cameraDao.Delete(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
