using Hotel.Models;


namespace Hotel.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClients();
        Task<Cliente> GetClientByCodiceFiscale(string codiceFiscale);
        Task AddClient(Cliente cliente);
        Task UpdateClient(Cliente cliente);
        Task DeleteClient(string codiceFiscale);
    }

}
