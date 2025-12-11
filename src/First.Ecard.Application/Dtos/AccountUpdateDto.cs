using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Dtos
{
    public class AccountUpdateDto
    {
        public AccountTypeEnum ? AccountType { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus ? Status { get; set; }
    }
}