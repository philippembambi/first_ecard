using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Clients.Commands;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Mappings
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientCreateDto, Client>();
            CreateMap<CreateClientCommand, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<Client, ClientSummary>();
            CreateMap<ClientUpdateDto, Client>();
        }
    }
}