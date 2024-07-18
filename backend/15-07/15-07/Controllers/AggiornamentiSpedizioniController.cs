using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

[Authorize(Roles = "Addetto,Amministratore")]
public class AggiornamentiSpedizioniController : Controller
{
    private readonly IConfiguration _configuration;

    public AggiornamentiSpedizioniController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var aggiornamenti = new List<AggiornamentoSpedizione>();

        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var command = new SqlCommand("SELECT * FROM AggiornamentiSpedizioni", connection);
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                aggiornamenti.Add(new AggiornamentoSpedizione
                {
                    IDAggiornamento = (int)reader["IDAggiornamento"],
                    IDSpedizione = (int)reader["IDSpedizione"],
                    Stato = reader["Stato"].ToString(),
                    Luogo = reader["Luogo"].ToString(),
                    Descrizione = reader["Descrizione"].ToString(),
                    DataOraAggiornamento = (DateTime)reader["DataOraAggiornamento"]
                });
            }
        }

        return View(aggiornamenti);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IDSpedizione,Stato,Luogo,Descrizione,DataOraAggiornamento")] AggiornamentoSpedizione aggiornamentoSpedizione)
    {
        if (ModelState.IsValid)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var command = new SqlCommand("INSERT INTO AggiornamentiSpedizioni (IDSpedizione, Stato, Luogo, Descrizione, DataOraAggiornamento) VALUES (@IDSpedizione, @Stato, @Luogo, @Descrizione, @DataOraAggiornamento)", connection);
                command.Parameters.AddWithValue("@IDSpedizione", aggiornamentoSpedizione.IDSpedizione);
                command.Parameters.AddWithValue("@Stato", aggiornamentoSpedizione.Stato);
                command.Parameters.AddWithValue("@Luogo", aggiornamentoSpedizione.Luogo);
                command.Parameters.AddWithValue("@Descrizione", aggiornamentoSpedizione.Descrizione);
                command.Parameters.AddWithValue("@DataOraAggiornamento", aggiornamentoSpedizione.DataOraAggiornamento);
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(aggiornamentoSpedizione);
    }

    // Aggiungi le altre operazioni CRUD (Edit, Delete, Details) utilizzando un approccio simile
}
