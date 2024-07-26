using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Hotel.Services
{
    public class PrenotazioneService : IPrenotazioneService
    {
        private readonly string _connectionString;

        public PrenotazioneService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Prenotazione>> GetAllReservations()
        {
            var reservations = new List<Prenotazione>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Prenotazioni", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        reservations.Add(new Prenotazione
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CodiceFiscaleCliente = reader["CodiceFiscaleCliente"].ToString(),
                            NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]),
                            DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]),
                            NumeroProgressivoAnno = Convert.ToInt32(reader["NumeroProgressivoAnno"]),
                            Anno = Convert.ToInt32(reader["Anno"]),
                            Dal = Convert.ToDateTime(reader["Dal"]),
                            Al = Convert.ToDateTime(reader["Al"]),
                            CaparraConfirmatoria = Convert.ToDecimal(reader["CaparraConfirmatoria"]),
                            TariffaApplicata = Convert.ToDecimal(reader["TariffaApplicata"]),
                            TrattamentoId = Convert.ToInt32(reader["TrattamentoId"])
                        });
                    }
                }
            }
            return reservations;
        }

        public async Task<Prenotazione> GetReservationById(int id)
        {
            Prenotazione reservation = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Prenotazioni WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        reservation = new Prenotazione
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CodiceFiscaleCliente = reader["CodiceFiscaleCliente"].ToString(),
                            NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]),
                            DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]),
                            NumeroProgressivoAnno = Convert.ToInt32(reader["NumeroProgressivoAnno"]),
                            Anno = Convert.ToInt32(reader["Anno"]),
                            Dal = Convert.ToDateTime(reader["Dal"]),
                            Al = Convert.ToDateTime(reader["Al"]),
                            CaparraConfirmatoria = Convert.ToDecimal(reader["CaparraConfirmatoria"]),
                            TariffaApplicata = Convert.ToDecimal(reader["TariffaApplicata"]),
                            TrattamentoId = Convert.ToInt32(reader["TrattamentoId"])
                        };
                    }
                }
            }
            return reservation;
        }

        public async Task<IEnumerable<Trattamento>> GetTrattamenti()
        {
            var trattamenti = new List<Trattamento>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Trattamenti", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        trattamenti.Add(new Trattamento
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descrizione = reader["Descrizione"].ToString(),
                            TariffaSupplementare = Convert.ToDecimal(reader["TariffaSupplementare"])
                        });
                    }
                }
            }
            return trattamenti;
        }

        public async Task AddReservation(Prenotazione prenotazione)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Prenotazioni (CodiceFiscaleCliente, NumeroCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, Dal, Al, CaparraConfirmatoria, TariffaApplicata, TrattamentoId) VALUES (@CodiceFiscaleCliente, @NumeroCamera, @DataPrenotazione, @NumeroProgressivoAnno, @Anno, @Dal, @Al, @CaparraConfirmatoria, @TariffaApplicata, @TrattamentoId)", connection);
                command.Parameters.AddWithValue("@CodiceFiscaleCliente", prenotazione.CodiceFiscaleCliente);
                command.Parameters.AddWithValue("@NumeroCamera", prenotazione.NumeroCamera);
                command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                command.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
                command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                command.Parameters.AddWithValue("@Dal", prenotazione.Dal);
                command.Parameters.AddWithValue("@Al", prenotazione.Al);
                command.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                command.Parameters.AddWithValue("@TariffaApplicata", prenotazione.TariffaApplicata);
                command.Parameters.AddWithValue("@TrattamentoId", prenotazione.TrattamentoId);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateReservation(Prenotazione prenotazione)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("UPDATE Prenotazioni SET CodiceFiscaleCliente = @CodiceFiscaleCliente, NumeroCamera = @NumeroCamera, DataPrenotazione = @DataPrenotazione, NumeroProgressivoAnno = @NumeroProgressivoAnno, Anno = @Anno, Dal = @Dal, Al = @Al, CaparraConfirmatoria = @CaparraConfirmatoria, TariffaApplicata = @TariffaApplicata, TrattamentoId = @TrattamentoId WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", prenotazione.Id);
                command.Parameters.AddWithValue("@CodiceFiscaleCliente", prenotazione.CodiceFiscaleCliente);
                command.Parameters.AddWithValue("@NumeroCamera", prenotazione.NumeroCamera);
                command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                command.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
                command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                command.Parameters.AddWithValue("@Dal", prenotazione.Dal);
                command.Parameters.AddWithValue("@Al", prenotazione.Al);
                command.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                command.Parameters.AddWithValue("@TariffaApplicata", prenotazione.TariffaApplicata);
                command.Parameters.AddWithValue("@TrattamentoId", prenotazione.TrattamentoId);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteReservation(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("DELETE FROM Prenotazioni WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }

}
