using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Models;

namespace Diama_sHotel.Services
{
    public class PrenotazioneService : IPrenotazioneService
    {
        private readonly string _connectionString;

        public PrenotazioneService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddPrenotazioneAsync(Prenotazione prenotazione)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Prenotazioni (IDCliente, IDCamera, DataPrenotazione, NumeroProgressivo, Anno, PeriodoDal, PeriodoAl, CaparraConfirmatoria, TariffaApplicata, TipologiaSoggiorno) " +
                               "VALUES (@IDCliente, @IDCamera, @DataPrenotazione, @NumeroProgressivo, @Anno, @PeriodoDal, @PeriodoAl, @CaparraConfirmatoria, @TariffaApplicata, @TipologiaSoggiorno)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCliente", prenotazione.IDCliente);
                command.Parameters.AddWithValue("@IDCamera", prenotazione.IDCamera);
                command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                command.Parameters.AddWithValue("@NumeroProgressivo", prenotazione.NumeroProgressivo);
                command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                command.Parameters.AddWithValue("@PeriodoDal", prenotazione.PeriodoDal);
                command.Parameters.AddWithValue("@PeriodoAl", prenotazione.PeriodoAl);
                command.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria.HasValue ? (object)prenotazione.CaparraConfirmatoria.Value : DBNull.Value);
                command.Parameters.AddWithValue("@TariffaApplicata", prenotazione.TariffaApplicata);
                command.Parameters.AddWithValue("@TipologiaSoggiorno", prenotazione.TipologiaSoggiorno);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<Prenotazione> GetPrenotazioneByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Prenotazioni WHERE IDPrenotazione = @IDPrenotazione";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDPrenotazione", id);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Prenotazione
                        {
                            IDPrenotazione = (int)reader["IDPrenotazione"],
                            IDCliente = (int)reader["IDCliente"],
                            IDCamera = (int)reader["IDCamera"],
                            DataPrenotazione = (DateTime)reader["DataPrenotazione"],
                            NumeroProgressivo = (int)reader["NumeroProgressivo"],
                            Anno = (int)reader["Anno"],
                            PeriodoDal = (DateTime)reader["PeriodoDal"],
                            PeriodoAl = (DateTime)reader["PeriodoAl"],
                            CaparraConfirmatoria = reader["CaparraConfirmatoria"] != DBNull.Value ? (decimal)reader["CaparraConfirmatoria"] : (decimal?)null,
                            TariffaApplicata = (decimal)reader["TariffaApplicata"],
                            TipologiaSoggiorno = (string)reader["TipologiaSoggiorno"]
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Prenotazione>> GetAllPrenotazioniAsync()
        {
            var prenotazioni = new List<Prenotazione>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Prenotazioni";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        prenotazioni.Add(new Prenotazione
                        {
                            IDPrenotazione = (int)reader["IDPrenotazione"],
                            IDCliente = (int)reader["IDCliente"],
                            IDCamera = (int)reader["IDCamera"],
                            DataPrenotazione = (DateTime)reader["DataPrenotazione"],
                            NumeroProgressivo = (int)reader["NumeroProgressivo"],
                            Anno = (int)reader["Anno"],
                            PeriodoDal = (DateTime)reader["PeriodoDal"],
                            PeriodoAl = (DateTime)reader["PeriodoAl"],
                            CaparraConfirmatoria = reader["CaparraConfirmatoria"] != DBNull.Value ? (decimal)reader["CaparraConfirmatoria"] : (decimal?)null,
                            TariffaApplicata = (decimal)reader["TariffaApplicata"],
                            TipologiaSoggiorno = (string)reader["TipologiaSoggiorno"]
                        });
                    }
                }
            }
            return prenotazioni;
        }

        public async Task<IEnumerable<Prenotazione>> GetPrenotazioniByClienteIdAsync(int clienteId)
        {
            var prenotazioni = new List<Prenotazione>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Prenotazioni WHERE IDCliente = @IDCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCliente", clienteId);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        prenotazioni.Add(new Prenotazione
                        {
                            IDPrenotazione = (int)reader["IDPrenotazione"],
                            IDCliente = (int)reader["IDCliente"],
                            IDCamera = (int)reader["IDCamera"],
                            DataPrenotazione = (DateTime)reader["DataPrenotazione"],
                            NumeroProgressivo = (int)reader["NumeroProgressivo"],
                            Anno = (int)reader["Anno"],
                            PeriodoDal = (DateTime)reader["PeriodoDal"],
                            PeriodoAl = (DateTime)reader["PeriodoAl"],
                            CaparraConfirmatoria = reader["CaparraConfirmatoria"] != DBNull.Value ? (decimal)reader["CaparraConfirmatoria"] : (decimal?)null,
                            TariffaApplicata = (decimal)reader["TariffaApplicata"],
                            TipologiaSoggiorno = (string)reader["TipologiaSoggiorno"]
                        });
                    }
                }
            }
            return prenotazioni;
        }

        public async Task<IEnumerable<Prenotazione>> GetPrenotazioniByTipologiaAsync(string tipologia)
        {
            var prenotazioni = new List<Prenotazione>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Prenotazioni WHERE TipologiaSoggiorno = @TipologiaSoggiorno";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TipologiaSoggiorno", tipologia);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        prenotazioni.Add(new Prenotazione
                        {
                            IDPrenotazione = (int)reader["IDPrenotazione"],
                            IDCliente = (int)reader["IDCliente"],
                            IDCamera = (int)reader["IDCamera"],
                            DataPrenotazione = (DateTime)reader["DataPrenotazione"],
                            NumeroProgressivo = (int)reader["NumeroProgressivo"],
                            Anno = (int)reader["Anno"],
                            PeriodoDal = (DateTime)reader["PeriodoDal"],
                            PeriodoAl = (DateTime)reader["PeriodoAl"],
                            CaparraConfirmatoria = reader["CaparraConfirmatoria"] != DBNull.Value ? (decimal)reader["CaparraConfirmatoria"] : (decimal?)null,
                            TariffaApplicata = (decimal)reader["TariffaApplicata"],
                            TipologiaSoggiorno = (string)reader["TipologiaSoggiorno"]
                        });
                    }
                }
            }
            return prenotazioni;
        }

        public async Task UpdatePrenotazioneAsync(Prenotazione prenotazione)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Prenotazioni SET IDCliente = @IDCliente, IDCamera = @IDCamera, DataPrenotazione = @DataPrenotazione, " +
                               "NumeroProgressivo = @NumeroProgressivo, Anno = @Anno, PeriodoDal = @PeriodoDal, PeriodoAl = @PeriodoAl, " +
                               "CaparraConfirmatoria = @CaparraConfirmatoria, TariffaApplicata = @TariffaApplicata, TipologiaSoggiorno = @TipologiaSoggiorno " +
                               "WHERE IDPrenotazione = @IDPrenotazione";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDPrenotazione", prenotazione.IDPrenotazione);
                command.Parameters.AddWithValue("@IDCliente", prenotazione.IDCliente);
                command.Parameters.AddWithValue("@IDCamera", prenotazione.IDCamera);
                command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                command.Parameters.AddWithValue("@NumeroProgressivo", prenotazione.NumeroProgressivo);
                command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                command.Parameters.AddWithValue("@PeriodoDal", prenotazione.PeriodoDal);
                command.Parameters.AddWithValue("@PeriodoAl", prenotazione.PeriodoAl);
                command.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria.HasValue ? (object)prenotazione.CaparraConfirmatoria.Value : DBNull.Value);
                command.Parameters.AddWithValue("@TariffaApplicata", prenotazione.TariffaApplicata);
                command.Parameters.AddWithValue("@TipologiaSoggiorno", prenotazione.TipologiaSoggiorno);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeletePrenotazioneAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Prenotazioni WHERE IDPrenotazione = @IDPrenotazione";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDPrenotazione", id);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
