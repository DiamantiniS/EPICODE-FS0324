using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "adminpass", Role = "admin" },
            new User { Id = 2, Username = "receptionist", Password = "receptionpass", Role = "receptionist" }
        };

        public User Login(string username, string password)
        {
            return _users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}

