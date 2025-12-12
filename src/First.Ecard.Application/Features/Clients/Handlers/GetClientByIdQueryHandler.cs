using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Exceptions;
using First.Ecard.Application.Features.Clients.Queries;
using First.Ecard.Application.Interfaces;
using First.Ecard.Domain.Entities;
using MediatR;

namespace First.Ecard.Application.Features.Clients.Handlers
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IMapper _mapper;   
        private readonly IGenericRepository<Client> _clientRepository;

        public GetClientByIdQueryHandler(IMapper mapper, IGenericRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id) ?? throw new FirstValidationException("Not found", new[] {$"No agent found with id {request.Id}"});
            return _mapper.Map<ClientDto>(client); 
        }
    }
}