using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Agents.Commands;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Mappings
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<AgentCreateDto, Agent>();
            CreateMap<CreateAgentCommand, Agent>();
            CreateMap<Agent, AgentDto>();
            CreateMap<AgentUpdateDto, Agent>();
        }
    }
}