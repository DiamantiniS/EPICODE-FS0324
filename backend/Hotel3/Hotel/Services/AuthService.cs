﻿using Hotel.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "admin", Role = "admin" },
            new User { Id = 2, Username = "receptionist", Password = "reception", Role = "receptionist" }
        };

        public User Login(string username, string password)
        {
            return _users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}

