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
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(FirstDbContext context) : base(context)
        {
            
        }

        public async Task<List<Card>> GetCardsByAccountIdAsync(int accountId)
        {
            return await _context.Cards
                .Where(c => c.AccountId == accountId)
                .ToListAsync();
        }
    }
}