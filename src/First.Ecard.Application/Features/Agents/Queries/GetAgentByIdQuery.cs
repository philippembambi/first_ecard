using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;

namespace First.Ecard.Application.Features.Agents.Queries
{
    public class GetAgentByIdQuery : IRequest<AgentDto>
    {
        public int AgentId {get; set;}
    }
}