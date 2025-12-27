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
    public class AccountRepository: GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(FirstDbContext context) : base(context)
        {
            
        }

        public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
        }

        public async Task<List<Account>> GetByClientIdAsync(int clientId)
        {
            return await _context.Accounts
                .Where(x => x.Client != null && x.Client.Id == clientId)
                .ToListAsync();
        }

        public async Task<List<Account>> GetAllWithClientAsync()
        {
            return await _context.Accounts
                .Include(a => a.Client)
                .Include(a => a.Cards)
                .ToListAsync();
        }

        public async Task<Account?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Accounts
                .Include(a => a.Client)
                .Include(a => a.Cards)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}