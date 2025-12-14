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
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public CardType CardType { get; set; }
        public string? CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int AccountId { get; set; }
    }
}