using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Cards.Commands;
using MediatR;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Interfaces;
using AutoMapper;

namespace First.Ecard.Application.Features.Cards.Handlers
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, CardDto>
    {
        public readonly IGenericRepository<Card> _cardRepository;
        public readonly IMapper _mapper;

        public CreateCardCommandHandler(IGenericRepository<Card> cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardDto> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = _mapper.Map<Card>(request);

            card.CardNumber = Card.GenerateCardNumber();
            card.CVV = Card.GenerateCVV();
            card.CreatedAt = DateTime.UtcNow;

            await _cardRepository.CreateAsync(card);
            return _mapper.Map<CardDto>(card);
        }
    }
}