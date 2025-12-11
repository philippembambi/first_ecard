using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Interfaces;
using First.Ecard.Domain.Entities;
using First.Ecard.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace First.Ecard.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(FirstDbContext context) : base(context)
        {
            
        }
        public async Task<Client?> GetClientWithAccountsAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.Accounts)
                .ThenInclude(a => a.Cards)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}