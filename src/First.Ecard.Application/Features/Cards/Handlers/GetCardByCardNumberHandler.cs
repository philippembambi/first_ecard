using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Cards.Queries;
using MediatR;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Interfaces;
using AutoMapper;

namespace First.Ecard.Application.Features.Cards.Handlers
{
    public class GetCardByCardNumberHandler : IRequestHandler<GetCardByCardNumberQuery, CardDto>
    {
        public readonly ICardRepository _cardRepository;
        public readonly IMapper _mapper;

        public GetCardByCardNumberHandler(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardDto> Handle(GetCardByCardNumberQuery request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetByCardNumberAsync(request.CardNumber);
            return _mapper.Map<CardDto>(cards);
        }
    }
}