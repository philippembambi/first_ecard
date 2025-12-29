using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Interfaces;
using First.Ecard.Domain.Entities;
using MediatR;
using First.Ecard.Application.Features.Agents.Queries;
using First.Ecard.Application.Exceptions;

namespace First.Ecard.Application.Features.Agents.Handlers
{
    public class GetAgentByIdQueryHandler : IRequestHandler<GetAgentByIdQuery, AgentDto>
    {
        public readonly IGenericRepository<Agent> _agentRepository;
        public readonly IMapper _mapper;

        public GetAgentByIdQueryHandler(IGenericRepository<Agent> agent, IMapper mapper)
        {
            _agentRepository = agent;
            _mapper = mapper;
        }

        public async Task<AgentDto> Handle(GetAgentByIdQuery request, CancellationToken cancellationToken)
        {
            var agent = await _agentRepository.GetByIdAsync(request.Id) ?? throw new FirstValidationException("Not found", new[] {$"No agent found with id {request.Id}"});
            return _mapper.Map<AgentDto>(agent); 
        }
    }
}