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
    public class GetAllUpdateCardsHandler : IRequestHandler<GetAllUpdateCards, List<CardDto>>
    {
        public readonly ICardRepository _cardRepository;
        public readonly IMapper _mapper;

        public GetAllUpdateCardsHandler(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<List<CardDto>> Handle(GetAllUpdateCards request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetUpdateCardsAsync();
            return _mapper.Map<List<CardDto>>(cards);
        }
    }
}