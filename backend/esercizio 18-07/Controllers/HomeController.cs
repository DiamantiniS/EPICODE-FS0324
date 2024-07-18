using Microsoft.AspNetCore.Mvc;
using esercizio_18_07.Models;

namespace esercizio_18_07.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle contact form submission
            }
            return View(model);
        }
    }
}
