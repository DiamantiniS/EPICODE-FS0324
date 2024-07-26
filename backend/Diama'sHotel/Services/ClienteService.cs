using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Services
{
    public class ClienteService : IClienteService
    {
        private readonly string _connectionString;

        public ClienteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Città, Provincia, Email, Telefono, Cellulare) " +
                               "VALUES (@CodiceFiscale, @Cognome, @Nome, @Città, @Provincia, @Email, @Telefono, @Cellulare)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@Città", cliente.Città);
                command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Clienti WHERE IDCliente = @IDCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCliente", id);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Cliente
                        {
                            IDCliente = (int)reader["IDCliente"],
                            CodiceFiscale = (string)reader["CodiceFiscale"],
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            Città = reader["Città"] as string,
                            Provincia = reader["Provincia"] as string,
                            Email = reader["Email"] as string,
                            Telefono = reader["Telefono"] as string,
                            Cellulare = reader["Cellulare"] as string
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<Cliente> GetClienteByCodiceFiscaleAsync(string codiceFiscale)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Clienti WHERE CodiceFiscale = @CodiceFiscale";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Cliente
                        {
                            IDCliente = (int)reader["IDCliente"],
                            CodiceFiscale = (string)reader["CodiceFiscale"],
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            Città = reader["Città"] as string,
                            Provincia = reader["Provincia"] as string,
                            Email = reader["Email"] as string,
                            Telefono = reader["Telefono"] as string,
                            Cellulare = reader["Cellulare"] as string
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllClientiAsync()
        {
            var clienti = new List<Cliente>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Clienti";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        clienti.Add(new Cliente
                        {
                            IDCliente = (int)reader["IDCliente"],
                            CodiceFiscale = (string)reader["CodiceFiscale"],
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            Città = reader["Città"] as string,
                            Provincia = reader["Provincia"] as string,
                            Email = reader["Email"] as string,
                            Telefono = reader["Telefono"] as string,
                            Cellulare = reader["Cellulare"] as string
                        });
                    }
                }
            }
            return clienti;
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Clienti SET CodiceFiscale = @CodiceFiscale, Cognome = @Cognome, Nome = @Nome, " +
                               "Città = @Città, Provincia = @Provincia, Email = @Email, Telefono = @Telefono, Cellulare = @Cellulare " +
                               "WHERE IDCliente = @IDCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCliente", cliente.IDCliente);
                command.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@Città", cliente.Città);
                command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteClienteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Clienti WHERE IDCliente = @IDCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCliente", id);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
