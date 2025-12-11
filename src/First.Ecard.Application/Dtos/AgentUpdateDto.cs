using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Dtos
{
    public class AgentUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public AgentRole Role { get; set; }
    }
}