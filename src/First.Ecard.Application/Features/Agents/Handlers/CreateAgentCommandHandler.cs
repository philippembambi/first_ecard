using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Dtos;
using MediatR;
using First.Ecard.Application.Interfaces;
using AutoMapper;
using First.Ecard.Application.Features.Agents.Commands;

namespace First.Ecard.Application.Features.Agents.Handlers
{
    public class CreateAgentCommandHandler : IRequestHandler<CreateAgentCommand, AgentDto>
    {
        public readonly IGenericRepository<Agent> _agentRepository;
        public readonly IMapper _mapper;
        public readonly IPasswordHasher _passwordHasher;

        public CreateAgentCommandHandler(IGenericRepository<Agent> agentRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<AgentDto> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            var agent = _mapper.Map<Agent>(request);
            var hashedPassword = _passwordHasher.CryptPassword(request.PasswordHash);

            agent.MatriculationNumber = Agent.GenerateMatriculationNumber();
            agent.CreatedAt = DateTime.UtcNow;
            agent.PasswordHash = hashedPassword;
            
            await _agentRepository.CreateAsync(agent);
            return _mapper.Map<AgentDto>(agent);  
        }
    }
}