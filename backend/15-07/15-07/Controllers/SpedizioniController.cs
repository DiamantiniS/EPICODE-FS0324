using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

[Authorize(Roles = "Addetto,Amministratore")]
public class SpedizioniController : Controller
{
    private readonly IConfiguration _configuration;

    public SpedizioniController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var spedizioni = new List<Spedizione>();

        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var command = new SqlCommand("SELECT * FROM Spedizioni", connection);
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                spedizioni.Add(new Spedizione
                {
                    IDSpedizione = (int)reader["IDSpedizione"],
                    IDCliente = (int)reader["IDCliente"],
                    NumeroIdentificativo = reader["NumeroIdentificativo"].ToString(),
                    DataSpedizione = (DateTime)reader["DataSpedizione"],
                    Peso = (decimal)reader["Peso"],
                    CittàDestinataria = reader["CittàDestinataria"].ToString(),
                    IndirizzoDestinatario = reader["IndirizzoDestinatario"].ToString(),
                    NominativoDestinatario = reader["NominativoDestinatario"].ToString(),
                    CostoSpedizione = (decimal)reader["CostoSpedizione"],
                    DataConsegnaPrevista = reader["DataConsegnaPrevista"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["DataConsegnaPrevista"]
                });
            }
        }

        return View(spedizioni);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IDCliente,NumeroIdentificativo,DataSpedizione,Peso,CittàDestinataria,IndirizzoDestinatario,NominativoDestinatario,CostoSpedizione,DataConsegnaPrevista")] Spedizione spedizione)
    {
        if (ModelState.IsValid)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var command = new SqlCommand("INSERT INTO Spedizioni (IDCliente, NumeroIdentificativo, DataSpedizione, Peso, CittàDestinataria, IndirizzoDestinatario, NominativoDestinatario, CostoSpedizione, DataConsegnaPrevista) VALUES (@IDCliente, @NumeroIdentificativo, @DataSpedizione, @Peso, @CittàDestinataria, @IndirizzoDestinatario, @NominativoDestinatario, @CostoSpedizione, @DataConsegnaPrevista)", connection);
                command.Parameters.AddWithValue("@IDCliente", spedizione.IDCliente);
                command.Parameters.AddWithValue("@NumeroIdentificativo", spedizione.NumeroIdentificativo);
                command.Parameters.AddWithValue("@DataSpedizione", spedizione.DataSpedizione);
                command.Parameters.AddWithValue("@Peso", spedizione.Peso);
                command.Parameters.AddWithValue("@CittàDestinataria", spedizione.CittàDestinataria);
                command.Parameters.AddWithValue("@IndirizzoDestinatario", spedizione.IndirizzoDestinatario);
                command.Parameters.AddWithValue("@NominativoDestinatario", spedizione.NominativoDestinatario);
                command.Parameters.AddWithValue("@CostoSpedizione", spedizione.CostoSpedizione);
                command.Parameters.AddWithValue("@DataConsegnaPrevista", (object)spedizione.DataConsegnaPrevista ?? DBNull.Value);
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(spedizione);
    }

    // Aggiungi le altre operazioni CRUD (Edit, Delete, Details) utilizzando un approccio simile
}
