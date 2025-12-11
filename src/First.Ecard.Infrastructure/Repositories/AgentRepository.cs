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
    public class AgentRepository : GenericRepository<Agent>, IAgentRepository
    {
        public AgentRepository(FirstDbContext context) : base(context)
        {
            
        }

        public async Task<Agent?> GetByMatriculeAsync(string matricule)
        {
            return await _context.Agents
                .FirstOrDefaultAsync(a => a.MatriculationNumber == matricule);
        }
    }
}