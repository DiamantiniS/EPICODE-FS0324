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
                var query = "SELECT v.idverbale, v.DataViolazione, v.IndirizzoViolazione, v.Nominativo_Agente, v.DataTrascrizioneVerbale, v.Importo, v.DecurtamentoPunti, v.idanagrafica, " +
                            "a.Nome, a.Cognome, vv.idviolazione, t.descrizione " +
                            "FROM VERBALE v " +
                            "JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica " +
                            "LEFT JOIN VERBALE_VIOLAZIONE vv ON v.idverbale = vv.idverbale " +
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
                                NominativoAgente = reader.GetString(3),  // Correzione: Nominativo_Agente
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
                var query = "SELECT v.idverbale, v.DataViolazione, v.IndirizzoViolazione, v.Nominativo_Agente, v.DataTrascrizioneVerbale, v.Importo, v.DecurtamentoPunti, v.idanagrafica, " +
                            "a.Nome, a.Cognome, vv.idviolazione, t.descrizione " +
                            "FROM VERBALE v " +
                            "JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica " +
                            "LEFT JOIN VERBALE_VIOLAZIONE vv ON v.idverbale = vv.idverbale " +
                            "LEFT JOIN TIPO_VIOLAZIONE t ON vv.idviolazione = t.idviolazione " +
                            "WHERE v.idverbale = @Id";
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
                                NominativoAgente = reader.GetString(3),  // Correzione: Nominativo_Agente
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
                var query = "INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, idanagrafica) " +
                            "VALUES (@DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @idanagrafica); " +
                            "SELECT SCOPE_IDENTITY();";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                    command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                    command.Parameters.AddWithValue("@Nominativo_Agente", verbale.NominativoAgente);  // Correzione: Nominativo_Agente
                    command.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                    command.Parameters.AddWithValue("@Importo", verbale.Importo);
                    command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                    command.Parameters.AddWithValue("@idanagrafica", verbale.AnagraficaId);
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
                            "Nominativo_Agente = @Nominativo_Agente, DataTrascrizioneVerbale = @DataTrascrizioneVerbale, " +
                            "Importo = @Importo, DecurtamentoPunti = @DecurtamentoPunti, idanagrafica = @idanagrafica WHERE idverbale = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DataViolazione", updatedVerbale.DataViolazione);
                    command.Parameters.AddWithValue("@IndirizzoViolazione", updatedVerbale.IndirizzoViolazione);
                    command.Parameters.AddWithValue("@Nominativo_Agente", updatedVerbale.NominativoAgente);  // Correzione: Nominativo_Agente
                    command.Parameters.AddWithValue("@DataTrascrizioneVerbale", updatedVerbale.DataTrascrizioneVerbale);
                    command.Parameters.AddWithValue("@Importo", updatedVerbale.Importo);
                    command.Parameters.AddWithValue("@DecurtamentoPunti", updatedVerbale.DecurtamentoPunti);
                    command.Parameters.AddWithValue("@idanagrafica", updatedVerbale.AnagraficaId);
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

                var queryDeleteVerbale = "DELETE FROM VERBALE WHERE idverbale = @Id";
                using (var command = new SqlCommand(queryDeleteVerbale, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Verbale> GetVerbaliTrasgressori()
        {
            var verbali = new List<Verbale>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM VERBALE"; // Modifica la query in base alle tue necessità
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            verbali.Add(new Verbale
                            {
                                Id = reader.GetInt32(0),
                                DataViolazione = reader.GetDateTime(1),
                                IndirizzoViolazione = reader.GetString(2),
                                NominativoAgente = reader.GetString(3),
                                DataTrascrizioneVerbale = reader.GetDateTime(4),
                                Importo = reader.GetDecimal(5),
                                DecurtamentoPunti = reader.GetInt32(6),
                                AnagraficaId = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            return verbali;
        }

        public List<Verbale> GetPuntiDecurtatiTrasgressori()
        {
            var verbali = new List<Verbale>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT v.idverbale, v.DataViolazione, v.IndirizzoViolazione, v.Nominativo_Agente, v.DataTrascrizioneVerbale, v.Importo, v.DecurtamentoPunti, v.idanagrafica, a.Nome, a.Cognome " +
                            "FROM VERBALE v " +
                            "JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            verbali.Add(new Verbale
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
                            });
                        }
                    }
                }
            }
            return verbali;
        }

        public List<Verbale> GetViolazioniOver400Euro()
        {
            var verbali = new List<Verbale>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT v.idverbale, v.DataViolazione, v.IndirizzoViolazione, v.Nominativo_Agente, v.DataTrascrizioneVerbale, v.Importo, v.DecurtamentoPunti, v.idanagrafica, a.Nome, a.Cognome " +
                            "FROM VERBALE v " +
                            "JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica " +
                            "WHERE v.Importo > 400";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            verbali.Add(new Verbale
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
                            });
                        }
                    }
                }
            }
            return verbali;
        }

        public List<Verbale> GetViolazioniOverTenPoints()
        {
            var verbali = new List<Verbale>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT v.idverbale, v.DataViolazione, v.IndirizzoViolazione, v.Nominativo_Agente, v.DataTrascrizioneVerbale, v.Importo, v.DecurtamentoPunti, v.idanagrafica, a.Nome, a.Cognome " +
                            "FROM VERBALE v " +
                            "JOIN ANAGRAFICA a ON v.idanagrafica = a.idanagrafica " +
                            "WHERE v.DecurtamentoPunti > 10";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            verbali.Add(new Verbale
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
                            });
                        }
                    }
                }
            }
            return verbali;
        }

        public IEnumerable<(string Cognome, string Nome, int TotalePunti)> GetTotalePuntiDecurtatiPerTrasgressore()
        {
            var result = new List<(string Cognome, string Nome, int TotalePunti)>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"
            SELECT A.Cognome, A.Nome, SUM(V.DecurtamentoPunti) AS TotalePunti
            FROM VERBALE V
            JOIN ANAGRAFICA A ON V.idanagrafica = A.idanagrafica
            GROUP BY A.Cognome, A.Nome", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetInt32(2)
                            ));
                        }
                    }
                }
            }

            return result;
        }
    }
}
