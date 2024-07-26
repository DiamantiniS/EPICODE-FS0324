using System.Collections.Generic;
using System.Linq;
using Hotel.Models;

namespace Hotel.Interfaces
{
    public interface IAuthService
    {
        User Login(string username, string password);
    }
}
