using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

public class VerificaSpedizioniController : Controller
{
    private readonly ApplicationDbContext _context;

    public VerificaSpedizioniController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string codiceFiscale, string numeroSpedizione)
    {
        if (string.IsNullOrEmpty(codiceFiscale) || string.IsNullOrEmpty(numeroSpedizione))
        {
            ModelState.AddModelError("", "Entrambi i campi sono obbligatori.");
            return View();
        }

        var spedizione = await _context.Spedizioni
            .Include(s => s.Cliente)
            .Include(s => s.AggiornamentiSpedizioni)
            .FirstOrDefaultAsync(s => s.Cliente.CodiceFiscale == codiceFiscale && s.NumeroIdentificativo == numeroSpedizione);

        if (spedizione == null)
        {
            ModelState.AddModelError("", "Spedizione non trovata.");
            return View();
        }

        return View("DettagliSpedizione", spedizione);
    }
}
