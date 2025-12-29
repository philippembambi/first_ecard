using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Interfaces;
using MediatR;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Features.Accounts.Queries;
using First.Ecard.Application.Features.Cards.Queries;

namespace First.Ecard.Application.Features.Cards.Handlers
{
    public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, CardDto>
    {
        public readonly IGenericRepository<Card> _cardRepository;
        public readonly IMapper _mapper;

        public GetCardByIdQueryHandler(IGenericRepository<Card> cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardDto> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(request.CardId);
            return _mapper.Map<CardDto>(card);
        }
    }
}