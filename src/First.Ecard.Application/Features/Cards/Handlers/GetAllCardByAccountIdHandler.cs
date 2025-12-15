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
    public class GetAllCardByAccountIdHandler : IRequestHandler<GetAllCardByAccountIdQuery, List<CardDto>>
    {
        public readonly ICardRepository _cardRepository;
        public readonly IMapper _mapper;

        public GetAllCardByAccountIdHandler(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<List<CardDto>> Handle(GetAllCardByAccountIdQuery request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetCardsByAccountIdAsync(request.AccountId);
            return _mapper.Map<List<CardDto>>(cards);
        }
    }
}