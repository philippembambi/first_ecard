using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class AccountResponse
    {
        public int Id { get; set;}
        public string AccountNumber { get; set;} = string.Empty;
        public string AccountType { get; set;} = string.Empty;
        public decimal Balance { get; set;}
        public string Currency { get; set;} = string.Empty;
        public string Status { get; set;} = string.Empty;
        public DateTime CreatedAt { get; set;}
        public ClientSummaryResponse? Client { get; set;}
    }
}