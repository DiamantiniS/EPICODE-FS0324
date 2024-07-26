using Diama_sHotel.Models;
using System.Threading.Tasks;

namespace Diama_sHotel.Interfaces
{
    public interface IDipendenteService
    {
        Task RegisterDipendenteAsync(Dipendente dipendente);
        Task<bool> AuthenticateAsync(string username, string password);
        Task<Dipendente> GetDipendenteByUsernameAsync(string username);
    }
}
