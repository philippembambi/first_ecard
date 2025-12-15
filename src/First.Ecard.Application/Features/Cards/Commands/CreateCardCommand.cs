using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using First.Ecard.Domain.Enums;
using MediatR;

namespace First.Ecard.Application.Features.Cards.Commands
{
    public class CreateCardCommand : IRequest<CardDto>
    {
        public CardType CardType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int AccountId { get; set; }
    }
}