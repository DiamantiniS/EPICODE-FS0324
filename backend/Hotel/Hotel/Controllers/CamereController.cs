using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Hotel.Controllers
{
    [Route("Admin/[controller]")]
    public class CamereController : Controller
    {
        private readonly ICameraService _cameraService;
        private readonly ILogger<CamereController> _logger;

        public CamereController(ICameraService cameraService, ILogger<CamereController> logger)
        {
            _cameraService = cameraService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rooms = await _cameraService.GetAllRooms();
            return View("~/Views/Admin/Camere/Index.cshtml", rooms);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] Camera camera)
        {
            _logger.LogInformation("Dati ricevuti per la creazione della camera: {@Camera}", camera);
            if (ModelState.IsValid)
            {
                await _cameraService.AddRoom(camera);
                _logger.LogInformation("Camera creata con successo: {@Camera}", camera);
                return Ok();
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            _logger.LogError("Errore durante la creazione della camera: {Errors}", errors);
            return BadRequest(new { Errors = errors });
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _cameraService.GetRoomByNumber(id);
            if (room == null)
            {
                return NotFound();
            }
            return Json(room);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromForm] Camera camera)
        {
            if (ModelState.IsValid)
            {
                await _cameraService.UpdateRoom(camera);
                return Ok();
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new { Errors = errors });
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int numero)
        {
            await _cameraService.DeleteRoom(numero);
            return Ok();
        }
    }
}
