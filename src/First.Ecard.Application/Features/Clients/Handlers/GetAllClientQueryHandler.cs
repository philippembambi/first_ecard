using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Clients.Queries;
using First.Ecard.Application.Interfaces;
using First.Ecard.Domain.Entities;
using MediatR;

namespace First.Ecard.Application.Features.Clients.Handlers
{
    public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, List<ClientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Client> _clientRepository;

        public GetAllClientQueryHandler(IMapper mapper, IGenericRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public async Task<List<ClientDto>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllAsync();
            return _mapper.Map<List<ClientDto>>(clients);
        }
    }
}