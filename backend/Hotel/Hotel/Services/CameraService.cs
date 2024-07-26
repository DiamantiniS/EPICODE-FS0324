using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class CameraService : ICameraService
    {
        private readonly string _connectionString;
        private readonly ILogger<CameraService> _logger;

        public CameraService(IConfiguration configuration, ILogger<CameraService> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<IEnumerable<Camera>> GetAllRooms()
        {
            var rooms = new List<Camera>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Camere", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        rooms.Add(new Camera
                        {
                            Numero = reader.GetInt32(0),
                            Descrizione = reader.GetString(1),
                            Tipologia = reader.GetString(2),
                            TariffaBase = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return rooms;
        }

        public async Task<Camera> GetRoomByNumber(int numero)
        {
            Camera room = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Camere WHERE Numero = @Numero", connection);
                command.Parameters.AddWithValue("@Numero", numero);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        room = new Camera
                        {
                            Numero = reader.GetInt32(0),
                            Descrizione = reader.GetString(1),
                            Tipologia = reader.GetString(2),
                            TariffaBase = reader.GetDecimal(3)
                        };
                    }
                }
            }
            return room;
        }

        public async Task AddRoom(Camera camera)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Camere (Numero, Descrizione, Tipologia, TariffaBase) VALUES (@Numero, @Descrizione, @Tipologia, @TariffaBase)", connection);
                command.Parameters.AddWithValue("@Numero", camera.Numero);
                command.Parameters.AddWithValue("@Descrizione", camera.Descrizione);
                command.Parameters.AddWithValue("@Tipologia", camera.Tipologia);
                command.Parameters.AddWithValue("@TariffaBase", camera.TariffaBase);
                await command.ExecuteNonQueryAsync();
                _logger.LogInformation("Camera creata con successo: Numero = {Numero}, Descrizione = {Descrizione}, Tipologia = {Tipologia}, TariffaBase = {TariffaBase}", camera.Numero, camera.Descrizione, camera.Tipologia, camera.TariffaBase);
            }
        }

        public async Task UpdateRoom(Camera camera)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("UPDATE Camere SET Descrizione = @Descrizione, Tipologia = @Tipologia, TariffaBase = @TariffaBase WHERE Numero = @Numero", connection);
                command.Parameters.AddWithValue("@Numero", camera.Numero);
                command.Parameters.AddWithValue("@Descrizione", camera.Descrizione);
                command.Parameters.AddWithValue("@Tipologia", camera.Tipologia);
                command.Parameters.AddWithValue("@TariffaBase", camera.TariffaBase);
                await command.ExecuteNonQueryAsync();
                _logger.LogInformation("Camera aggiornata con successo: Numero = {Numero}, Descrizione = {Descrizione}, Tipologia = {Tipologia}, TariffaBase = {TariffaBase}", camera.Numero, camera.Descrizione, camera.Tipologia, camera.TariffaBase);
            }
        }

        public async Task DeleteRoom(int numero)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("DELETE FROM Camere WHERE Numero = @Numero", connection);
                command.Parameters.AddWithValue("@Numero", numero);
                await command.ExecuteNonQueryAsync();
                _logger.LogInformation("Camera eliminata con successo: Numero = {Numero}", numero);
            }
        }
    }
}
