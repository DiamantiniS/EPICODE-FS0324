using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

[Authorize(Roles = "Addetto,Amministratore")]
public class ClientiController : Controller
{
    private readonly IConfiguration _configuration;

    public ClientiController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var clienti = new List<Cliente>();

        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var command = new SqlCommand("SELECT * FROM Clienti", connection);
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                clienti.Add(new Cliente
                {
                    IDCliente = (int)reader["IDCliente"],
                    Nome = reader["Nome"].ToString(),
                    TipoCliente = reader["TipoCliente"].ToString(),
                    CodiceFiscale = reader["CodiceFiscale"].ToString(),
                    PartitaIVA = reader["PartitaIVA"].ToString(),
                    Indirizzo = reader["Indirizzo"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }
        }

        return View(clienti);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nome,TipoCliente,CodiceFiscale,PartitaIVA,Indirizzo,Telefono,Email")] Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var command = new SqlCommand("INSERT INTO Clienti (Nome, TipoCliente, CodiceFiscale, PartitaIVA, Indirizzo, Telefono, Email) VALUES (@Nome, @TipoCliente, @CodiceFiscale, @PartitaIVA, @Indirizzo, @Telefono, @Email)", connection);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@TipoCliente", cliente.TipoCliente);
                command.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                command.Parameters.AddWithValue("@PartitaIVA", cliente.PartitaIVA);
                command.Parameters.AddWithValue("@Indirizzo", cliente.Indirizzo);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    // Aggiungi le altre operazioni CRUD (Edit, Delete, Details) utilizzando un approccio simile
}
