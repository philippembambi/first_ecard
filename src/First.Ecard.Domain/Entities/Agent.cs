using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Common;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Domain.Entities
{
    public class Agent : User
    {
        public AgentRole Role { get; set; }
        public string MatriculationNumber { get; set; } = string.Empty;
        public DateTime LastLogin { get; set; }
        public static string GenerateMatriculationNumber()
        {
            return string.Concat("000", DateTime.UtcNow.Ticks.ToString().Substring(1, 6));
        }

        public void UpdateLastLogin()
        {
            LastLogin = DateTime.UtcNow;
        }
    }
}