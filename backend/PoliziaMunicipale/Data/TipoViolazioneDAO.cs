using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Data
{
    public class TipoViolazioneDAO
    {
        private readonly string _connectionString;

        public TipoViolazioneDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<TipoViolazione> GetAll()
        {
            var violazioni = new List<TipoViolazione>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM TIPO_VIOLAZIONE";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            violazioni.Add(new TipoViolazione
                            {
                                Id = reader.GetInt32(0),
                                Descrizione = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return violazioni;
        }

        public TipoViolazione GetById(int id)
        {
            TipoViolazione violazione = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM TIPO_VIOLAZIONE WHERE idviolazione = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            violazione = new TipoViolazione
                            {
                                Id = reader.GetInt32(0),
                                Descrizione = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return violazione;
        }

        public void Create(TipoViolazione violazione)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO TIPO_VIOLAZIONE (descrizione) VALUES (@Descrizione)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Descrizione", violazione.Descrizione);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(int id, TipoViolazione updatedViolazione)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE TIPO_VIOLAZIONE SET descrizione = @Descrizione WHERE idviolazione = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Descrizione", updatedViolazione.Descrizione);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM TIPO_VIOLAZIONE WHERE idviolazione = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
