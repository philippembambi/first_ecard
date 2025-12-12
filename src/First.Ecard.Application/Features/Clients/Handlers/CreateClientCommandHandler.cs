using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Clients.Commands;
using First.Ecard.Application.Interfaces;
using First.Ecard.Domain.Entities;
using MediatR;

namespace First.Ecard.Application.Features.Clients.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Client> _clientRepository;
 
        public CreateClientCommandHandler(IMapper mapper, IGenericRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClientDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);

            client.CreatedAt = DateTime.UtcNow;
            
            await _clientRepository.CreateAsync(client);
            return _mapper.Map<ClientDto>(client); 
        }
    }
}