using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Dtos
{
    public class AgentDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public GenderType Gender { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public AgentRole Role { get; set; }
        public string? MatriculationNumber { get; set; }
        public DateTime LastLogin { get; set; }
    }
}