using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Data
{
    public class VerbaleDAO
    {
        private readonly string _connectionString;

        public VerbaleDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Verbale> GetAll()
        {
            var verbali = new List<Verbale>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT v.Id, v.DataViolazione, v.IndirizzoViolazione, v.NominativoAgente, v.DataTrascrizioneVerbale, v.Importo, v.DecurtamentoPunti, v.AnagraficaId, " +
                            "a.Nome, a.Cognome, vv.idviolazione, t.descrizione " +
                            "FROM VERBALE v " +
                            "JOIN ANAGRAFICA a ON v.AnagraficaId = a.Id " +
                            "LEFT JOIN VERBALE_VIOLAZIONE vv ON v.Id = vv.idverbale " +
                            "LEFT JOIN TIPO_VIOLAZIONE t ON vv.idviolazione = t.idviolazione";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var verbale = new Verbale
                            {
                                Id = reader.GetInt32(0),
                                DataViolazione = reader.GetDateTime(1),
                                IndirizzoViolazione = reader.GetString(2),
                                NominativoAgente = reader.GetString(3),
                                DataTrascrizioneVerbale = reader.GetDateTime(4),
                                Importo = reader.GetDecimal(5),
                                DecurtamentoPunti = reader.GetInt32(6),
                                AnagraficaId = reader.GetInt32(7),
                                Anagrafica = new Anagrafica
                                {
                                    Id = reader.GetInt32(7),
                                    Nome = reader.GetString(8),
                                    Cognome = reader.GetString(9)
                                }
                            };

                            if (!reader.IsDBNull(10))
                            {
                                verbale.Violazioni.Add(new TipoViolazione
                                {
                                    Id = reader.GetInt32(10),
                                    Descrizione = reader.GetString(11)
                                });
                            }

                            verbali.Add(verbale);
                        }
                    }
                }
            }
            return verbali;
        }

        public Verbale GetById(int id)
        {
            Verbale verbale = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT v.Id, v.DataViolazione, v.IndirizzoViolazione, v.NominativoAgente, v.DataTrascrizioneVerbale, v.Importo, v.DecurtamentoPunti, v.AnagraficaId, " +
                            "a.Nome, a.Cognome, vv.idviolazione, t.descrizione " +
                            "FROM VERBALE v " +
                            "JOIN ANAGRAFICA a ON v.AnagraficaId = a.Id " +
                            "LEFT JOIN VERBALE_VIOLAZIONE vv ON v.Id = vv.idverbale " +
                            "LEFT JOIN TIPO_VIOLAZIONE t ON vv.idviolazione = t.idviolazione " +
                            "WHERE v.Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            verbale = new Verbale
                            {
                                Id = reader.GetInt32(0),
                                DataViolazione = reader.GetDateTime(1),
                                IndirizzoViolazione = reader.GetString(2),
                                NominativoAgente = reader.GetString(3),
                                DataTrascrizioneVerbale = reader.GetDateTime(4),
                                Importo = reader.GetDecimal(5),
                                DecurtamentoPunti = reader.GetInt32(6),
                                AnagraficaId = reader.GetInt32(7),
                                Anagrafica = new Anagrafica
                                {
                                    Id = reader.GetInt32(7),
                                    Nome = reader.GetString(8),
                                    Cognome = reader.GetString(9)
                                }
                            };

                            if (!reader.IsDBNull(10))
                            {
                                verbale.Violazioni.Add(new TipoViolazione
                                {
                                    Id = reader.GetInt32(10),
                                    Descrizione = reader.GetString(11)
                                });
                            }
                        }
                    }
                }
            }
            return verbale;
        }

        public void Create(Verbale verbale)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, AnagraficaId) " +
                            "VALUES (@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @AnagraficaId); " +
                            "SELECT SCOPE_IDENTITY();";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                    command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                    command.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                    command.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                    command.Parameters.AddWithValue("@Importo", verbale.Importo);
                    command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                    command.Parameters.AddWithValue("@AnagraficaId", verbale.AnagraficaId);
                    var id = Convert.ToInt32(command.ExecuteScalar());
                    verbale.Id = id;
                }

                foreach (var violazione in verbale.Violazioni)
                {
                    var queryViolazione = "INSERT INTO VERBALE_VIOLAZIONE (idverbale, idviolazione) VALUES (@IdVerbale, @IdViolazione)";
                    using (var command = new SqlCommand(queryViolazione, connection))
                    {
                        command.Parameters.AddWithValue("@IdVerbale", verbale.Id);
                        command.Parameters.AddWithValue("@IdViolazione", violazione.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Update(int id, Verbale updatedVerbale)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE VERBALE SET DataViolazione = @DataViolazione, IndirizzoViolazione = @IndirizzoViolazione, " +
                            "NominativoAgente = @NominativoAgente, DataTrascrizioneVerbale = @DataTrascrizioneVerbale, " +
                            "Importo = @Importo, DecurtamentoPunti = @DecurtamentoPunti, AnagraficaId = @AnagraficaId WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DataViolazione", updatedVerbale.DataViolazione);
                    command.Parameters.AddWithValue("@IndirizzoViolazione", updatedVerbale.IndirizzoViolazione);
                    command.Parameters.AddWithValue("@NominativoAgente", updatedVerbale.NominativoAgente);
                    command.Parameters.AddWithValue("@DataTrascrizioneVerbale", updatedVerbale.DataTrascrizioneVerbale);
                    command.Parameters.AddWithValue("@Importo", updatedVerbale.Importo);
                    command.Parameters.AddWithValue("@DecurtamentoPunti", updatedVerbale.DecurtamentoPunti);
                    command.Parameters.AddWithValue("@AnagraficaId", updatedVerbale.AnagraficaId);
                    command.ExecuteNonQuery();
                }

                var queryDeleteViolazioni = "DELETE FROM VERBALE_VIOLAZIONE WHERE idverbale = @Id";
                using (var command = new SqlCommand(queryDeleteViolazioni, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                foreach (var violazione in updatedVerbale.Violazioni)
                {
                    var queryViolazione = "INSERT INTO VERBALE_VIOLAZIONE (idverbale, idviolazione) VALUES (@IdVerbale, @IdViolazione)";
                    using (var command = new SqlCommand(queryViolazione, connection))
                    {
                        command.Parameters.AddWithValue("@IdVerbale", id);
                        command.Parameters.AddWithValue("@IdViolazione", violazione.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var queryDeleteViolazioni = "DELETE FROM VERBALE_VIOLAZIONE WHERE idverbale = @Id";
                using (var command = new SqlCommand(queryDeleteViolazioni, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                var queryDeleteVerbale = "DELETE FROM VERBALE WHERE Id = @Id";
                using (var command = new SqlCommand(queryDeleteVerbale, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
