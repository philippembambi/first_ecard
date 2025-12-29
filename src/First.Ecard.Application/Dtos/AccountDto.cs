using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public AccountTypeEnum ? AccountType { get; set; }
        public decimal Balance { get; set; }
        public CurrencyType ? Currency { get; set; }
        public AccountStatus ? Status { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }

        public required ClientSummary Client { get; set; }
    }
}