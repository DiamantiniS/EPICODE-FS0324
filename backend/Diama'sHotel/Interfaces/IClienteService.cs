using Diama_sHotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diama_sHotel.Interfaces
{
    public interface IClienteService
    {
        Task AddClienteAsync(Cliente cliente);
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> GetClienteByCodiceFiscaleAsync(string codiceFiscale);
        Task<IEnumerable<Cliente>> GetAllClientiAsync();
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}
