﻿using Hotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Interfaces
{
    public interface IPrenotazioneDao
    {
        IEnumerable<Prenotazione> GetAll();
        Prenotazione GetById(int id);
        void Add(Prenotazione prenotazione);
        void Update(Prenotazione prenotazione);
        void Delete(int id);
        int GetLastId();
        void UpdateServizi(int prenotazioneId, List<int> serviziSelezionati);

        IEnumerable<Prenotazione> GetPrenotazioniByCodiceFiscale(string codiceFiscale);
        int GetTotalePrenotazioniPerTipologia(string tipologiaSoggiorno);
    }
}
