using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
