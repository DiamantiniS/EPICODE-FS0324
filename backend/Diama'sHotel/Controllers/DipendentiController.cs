using Microsoft.AspNetCore.Mvc;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Controllers
{
    public class DipendentiController : Controller
    {
        private readonly IDipendenteService _dipendenteService;

        public DipendentiController(IDipendenteService dipendenteService)
        {
            _dipendenteService = dipendenteService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Dipendente dipendente)
        {
            if (ModelState.IsValid)
            {
                await _dipendenteService.RegisterDipendenteAsync(dipendente);
                return RedirectToAction(nameof(Login));
            }
            return View(dipendente);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (await _dipendenteService.AuthenticateAsync(username, password))
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
    }
}
