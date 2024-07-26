using System.Data;
using Microsoft.Data.SqlClient; // Usa Microsoft.Data.SqlClient esplicitamente
using BCrypt.Net;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Services
{
    public class DipendenteService : IDipendenteService
    {
        private readonly string _connectionString;

        public DipendenteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task RegisterDipendenteAsync(Dipendente dipendente)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dipendente.PasswordHash);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Dipendenti (Username, PasswordHash, Nome, Cognome, Email, Ruolo) " +
                               "VALUES (@Username, @PasswordHash, @Nome, @Cognome, @Email, @Ruolo)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", dipendente.Username);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                command.Parameters.AddWithValue("@Nome", dipendente.Nome);
                command.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                command.Parameters.AddWithValue("@Email", dipendente.Email);
                command.Parameters.AddWithValue("@Ruolo", dipendente.Ruolo);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT PasswordHash FROM Dipendenti WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                await connection.OpenAsync();
                string storedHash = (string)await command.ExecuteScalarAsync();

                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
        }

        public async Task<Dipendente> GetDipendenteByUsernameAsync(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Dipendenti WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Dipendente
                        {
                            IDDipendente = (int)reader["IDDipendente"],
                            Username = (string)reader["Username"],
                            PasswordHash = (string)reader["PasswordHash"],
                            Nome = reader["Nome"] as string,
                            Cognome = reader["Cognome"] as string,
                            Email = reader["Email"] as string,
                            Ruolo = (string)reader["Ruolo"]
                        };
                    }
                    return null;
                }
            }
        }
    }
}
