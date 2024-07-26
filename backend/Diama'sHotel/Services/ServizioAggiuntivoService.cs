using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Services
{
    public class ServizioAggiuntivoService : IServizioAggiuntivoService
    {
        private readonly string _connectionString;

        public ServizioAggiuntivoService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddServizioAggiuntivoAsync(ServizioAggiuntivo servizio)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO ServiziAggiuntivi (Descrizione, PrezzoUnitario) VALUES (@Descrizione, @PrezzoUnitario)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Descrizione", servizio.Descrizione);
                command.Parameters.AddWithValue("@PrezzoUnitario", servizio.PrezzoUnitario);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<ServizioAggiuntivo> GetServizioAggiuntivoByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ServiziAggiuntivi WHERE IDServizio = @IDServizio";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDServizio", id);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new ServizioAggiuntivo
                        {
                            IDServizio = (int)reader["IDServizio"],
                            Descrizione = (string)reader["Descrizione"],
                            PrezzoUnitario = (decimal)reader["PrezzoUnitario"]
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<IEnumerable<ServizioAggiuntivo>> GetAllServiziAggiuntiviAsync()
        {
            var servizi = new List<ServizioAggiuntivo>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ServiziAggiuntivi";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        servizi.Add(new ServizioAggiuntivo
                        {
                            IDServizio = (int)reader["IDServizio"],
                            Descrizione = (string)reader["Descrizione"],
                            PrezzoUnitario = (decimal)reader["PrezzoUnitario"]
                        });
                    }
                }
            }
            return servizi;
        }

        public async Task UpdateServizioAggiuntivoAsync(ServizioAggiuntivo servizio)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE ServiziAggiuntivi SET Descrizione = @Descrizione, PrezzoUnitario = @PrezzoUnitario WHERE IDServizio = @IDServizio";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDServizio", servizio.IDServizio);
                command.Parameters.AddWithValue("@Descrizione", servizio.Descrizione);
                command.Parameters.AddWithValue("@PrezzoUnitario", servizio.PrezzoUnitario);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteServizioAggiuntivoAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM ServiziAggiuntivi WHERE IDServizio = @IDServizio";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDServizio", id);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
