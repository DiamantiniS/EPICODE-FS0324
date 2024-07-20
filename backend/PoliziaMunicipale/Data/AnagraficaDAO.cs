using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Data
{
    public class AnagraficaDAO
    {
        private readonly string _connectionString;

        public AnagraficaDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Anagrafica> GetAll()
        {
            var anagrafiche = new List<Anagrafica>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT idanagrafica, Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc FROM ANAGRAFICA";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            anagrafiche.Add(new Anagrafica
                            {
                                Id = reader.GetInt32(0),
                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Indirizzo = reader.GetString(3),
                                Citta = reader.GetString(4),
                                CAP = reader.GetString(5),
                                Cod_Fisc = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return anagrafiche;
        }

        public Anagrafica GetById(int id)
        {
            Anagrafica anagrafica = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT idanagrafica, Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc FROM ANAGRAFICA WHERE idanagrafica = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            anagrafica = new Anagrafica
                            {
                                Id = reader.GetInt32(0),
                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Indirizzo = reader.GetString(3),
                                Citta = reader.GetString(4),
                                CAP = reader.GetString(5),
                                Cod_Fisc = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return anagrafica;
        }

        public void Create(Anagrafica anagrafica)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO ANAGRAFICA (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc) VALUES (@Cognome, @Nome, @Indirizzo, @Città, @CAP, @Cod_Fisc)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                    command.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                    command.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                    command.Parameters.AddWithValue("@Città", anagrafica.Citta);
                    command.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                    command.Parameters.AddWithValue("@Cod_Fisc", anagrafica.Cod_Fisc);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(int id, Anagrafica updatedAnagrafica)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE ANAGRAFICA SET Cognome = @Cognome, Nome = @Nome, Indirizzo = @Indirizzo, Città = @Città, CAP = @CAP, Cod_Fisc = @Cod_Fisc WHERE idanagrafica = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Cognome", updatedAnagrafica.Cognome);
                    command.Parameters.AddWithValue("@Nome", updatedAnagrafica.Nome);
                    command.Parameters.AddWithValue("@Indirizzo", updatedAnagrafica.Indirizzo);
                    command.Parameters.AddWithValue("@Città", updatedAnagrafica.Citta);
                    command.Parameters.AddWithValue("@CAP", updatedAnagrafica.CAP);
                    command.Parameters.AddWithValue("@Cod_Fisc", updatedAnagrafica.Cod_Fisc);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Elimina i record correlati nella tabella VERBALE
                var deleteVerbaliQuery = "DELETE FROM VERBALE WHERE idanagrafica = @Id";
                using (var command = new SqlCommand(deleteVerbaliQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                // Elimina il record nella tabella ANAGRAFICA
                var deleteAnagraficaQuery = "DELETE FROM ANAGRAFICA WHERE idanagrafica = @Id";
                using (var command = new SqlCommand(deleteAnagraficaQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
