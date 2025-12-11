using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Dtos
{
    public class CardDto
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public CardType CardType { get; set; }
        public string? CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}