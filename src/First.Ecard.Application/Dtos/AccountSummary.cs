using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Dtos
{
    public class AccountSummary
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public AccountTypeEnum? AccountType { get; set; }
        public CurrencyType? Currency { get; set; }
    }
}