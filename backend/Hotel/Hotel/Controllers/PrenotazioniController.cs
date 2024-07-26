using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    [Route("Admin/Prenotazioni")]
    public class PrenotazioniController : Controller
    {
        private readonly IPrenotazioneService _prenotazioneService;
        private readonly ICameraService _cameraService;
        private readonly IClienteService _clienteService;

        public PrenotazioniController(IPrenotazioneService prenotazioneService, ICameraService cameraService, IClienteService clienteService)
        {
            _prenotazioneService = prenotazioneService;
            _cameraService = cameraService;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reservations = await _prenotazioneService.GetAllReservations();
            ViewBag.Clienti = await _clienteService.GetAllClients();
            ViewBag.Camere = await _cameraService.GetAllRooms();
            ViewBag.Trattamenti = await _prenotazioneService.GetTrattamenti();
            return View("~/Views/Admin/Prenotazioni/Index.cshtml", reservations);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                await _prenotazioneService.AddReservation(prenotazione);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _prenotazioneService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Json(reservation);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                await _prenotazioneService.UpdateReservation(prenotazione);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _prenotazioneService.DeleteReservation(id);
            return Ok();
        }
    }
}
