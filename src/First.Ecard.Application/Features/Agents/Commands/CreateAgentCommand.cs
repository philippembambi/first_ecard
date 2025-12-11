using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Features.Agents.Commands
{
    public class CreateAgentCommand : IRequest<AgentDto>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public GenderType Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public AgentRole Role { get; set; }
    }
}