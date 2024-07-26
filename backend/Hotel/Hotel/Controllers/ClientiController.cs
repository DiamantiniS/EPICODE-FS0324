using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    [Route("Admin/Clienti")]
    public class ClientiController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientiController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _clienteService.GetAllClients();
            return View("~/Views/Admin/Clienti/Index.cshtml", clients);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.AddClient(cliente);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var client = await _clienteService.GetClientByCodiceFiscale(id);
            if (client == null)
            {
                return NotFound();
            }
            return Json(client);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.UpdateClient(cliente);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(string codiceFiscale)
        {
            await _clienteService.DeleteClient(codiceFiscale);
            return Ok();
        }
    }
}
