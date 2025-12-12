using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Common;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Interfaces
{
    public interface IJwtService
    {
      string GenerateAccessToken(Agent user); 
      string GenerateRefreshToken();  
    }
}