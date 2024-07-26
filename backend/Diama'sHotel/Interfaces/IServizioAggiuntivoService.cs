using Diama_sHotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diama_sHotel.Interfaces
{
    public interface IServizioAggiuntivoService
    {
        Task AddServizioAggiuntivoAsync(ServizioAggiuntivo servizio);
        Task<ServizioAggiuntivo> GetServizioAggiuntivoByIdAsync(int id);
        Task<IEnumerable<ServizioAggiuntivo>> GetAllServiziAggiuntiviAsync();
        Task UpdateServizioAggiuntivoAsync(ServizioAggiuntivo servizio);
        Task DeleteServizioAggiuntivoAsync(int id);
    }
}
