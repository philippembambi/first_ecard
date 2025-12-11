using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Domain.Exceptions
{
    public class CardException : Exception
    {
        public CardException(string message) : base(message)
        {
        }
    }
}