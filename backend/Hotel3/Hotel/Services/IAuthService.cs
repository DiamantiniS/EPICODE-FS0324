
using Hotel.Models;

namespace Hotel.Services
{
    public interface IAuthService
    {
        User Login(string username, string password);
    }
}
