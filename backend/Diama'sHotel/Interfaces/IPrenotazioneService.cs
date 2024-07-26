using Diama_sHotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diama_sHotel.Interfaces
{
    public interface IPrenotazioneService
    {
        Task AddPrenotazioneAsync(Prenotazione prenotazione);
        Task<Prenotazione> GetPrenotazioneByIdAsync(int id);
        Task<IEnumerable<Prenotazione>> GetAllPrenotazioniAsync();
        Task<IEnumerable<Prenotazione>> GetPrenotazioniByClienteIdAsync(int clienteId);
        Task<IEnumerable<Prenotazione>> GetPrenotazioniByTipologiaAsync(string tipologia);
        Task UpdatePrenotazioneAsync(Prenotazione prenotazione);
        Task DeletePrenotazioneAsync(int id);
    }
}
