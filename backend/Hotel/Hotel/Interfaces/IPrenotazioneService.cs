using Hotel.Models;

namespace Hotel.Interfaces
{
    public interface IPrenotazioneService
    {
        Task<IEnumerable<Prenotazione>> GetAllReservations();
        Task<Prenotazione> GetReservationById(int id);
        Task<IEnumerable<Trattamento>> GetTrattamenti();
        Task AddReservation(Prenotazione prenotazione);
        Task UpdateReservation(Prenotazione prenotazione);
        Task DeleteReservation(int id);
    }

}
