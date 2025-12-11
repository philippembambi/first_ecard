using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        
    }
}