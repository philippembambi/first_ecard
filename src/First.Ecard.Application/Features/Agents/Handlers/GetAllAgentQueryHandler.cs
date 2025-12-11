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

namespace First.Ecard.Application.Features.Agents.Handlers
{
    public class GetAllAgentQueryHandler : IRequestHandler<GetAllAgentQuery, List<AgentDto>>
    {
        public readonly IGenericRepository<Agent> _agentRepository;
        public readonly IMapper _mapper;

        public GetAllAgentQueryHandler(IGenericRepository<Agent> agent, IMapper mapper)
        {
            _agentRepository = agent;
            _mapper = mapper;            
        }

        public async Task<List<AgentDto>> Handle(GetAllAgentQuery query, CancellationToken cancellationToken)
        {
            var agents = await _agentRepository.GetAllAsync();
            return _mapper.Map<List<AgentDto>>(agents);
        }
    }
}