using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class CardResponse
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public AccountSummaryResponse? Account { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}