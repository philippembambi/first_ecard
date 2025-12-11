using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string CryptPassword(string password);
        bool Verify(string hash, string password);
    }
}