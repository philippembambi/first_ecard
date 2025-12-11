using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;
using First.Ecard.Application.Interfaces;

namespace First.Ecard.Infrastructure.Repositories
{
    public class PasswordHasher : IPasswordHasher
    {
        public string CryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string hash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}