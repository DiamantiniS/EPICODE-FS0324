using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Services
{
    public class CameraService : ICameraService
    {
        private readonly string _connectionString;

        public CameraService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddCameraAsync(Camera camera)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Camere (Numero, Descrizione, Tipologia) VALUES (@Numero, @Descrizione, @Tipologia)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Numero", camera.Numero);
                command.Parameters.AddWithValue("@Descrizione", camera.Descrizione);
                command.Parameters.AddWithValue("@Tipologia", camera.Tipologia);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<Camera> GetCameraByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Camere WHERE IDCamera = @IDCamera";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCamera", id);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Camera
                        {
                            IDCamera = (int)reader["IDCamera"],
                            Numero = (string)reader["Numero"],
                            Descrizione = reader["Descrizione"] as string,
                            Tipologia = (string)reader["Tipologia"]
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Camera>> GetAllCamereAsync()
        {
            var camere = new List<Camera>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Camere";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        camere.Add(new Camera
                        {
                            IDCamera = (int)reader["IDCamera"],
                            Numero = (string)reader["Numero"],
                            Descrizione = reader["Descrizione"] as string,
                            Tipologia = (string)reader["Tipologia"]
                        });
                    }
                }
            }
            return camere;
        }

        public async Task UpdateCameraAsync(Camera camera)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Camere SET Numero = @Numero, Descrizione = @Descrizione, Tipologia = @Tipologia WHERE IDCamera = @IDCamera";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCamera", camera.IDCamera);
                command.Parameters.AddWithValue("@Numero", camera.Numero);
                command.Parameters.AddWithValue("@Descrizione", camera.Descrizione);
                command.Parameters.AddWithValue("@Tipologia", camera.Tipologia);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteCameraAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Camere WHERE IDCamera = @IDCamera";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCamera", id);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
