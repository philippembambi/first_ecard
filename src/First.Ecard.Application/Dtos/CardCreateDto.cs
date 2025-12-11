using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Dtos
{
    public class CardCreateDto
    {
        public CardType CardType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int AccountId { get; set; }
    }
}