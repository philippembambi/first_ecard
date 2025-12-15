using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Common;
using First.Ecard.Domain.Exceptions;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; } = string.Empty;
        public CardType CardType { get; set; }
        public string CVV { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public bool IsUpdatedCard() => ExpiryDate >= DateTime.UtcNow;
        public static string GenerateCardNumber()
        {
            var random = new Random();
            return string.Concat(Enumerable.Range(0, 16).Select(_ => random.Next(0, 10).ToString()));
        }
        public static string GenerateCVV()
        {
            var random = new Random();
            return random.Next(100, 999).ToString();
        }
    }
}