using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Application.Exceptions
{
    public class NotFoundException(string name, object key) : Exception($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}