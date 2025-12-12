using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using First.Ecard.Application.Dtos;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<AccountDto>
    {
        public int AccountId {get;set;}
        public AccountTypeEnum AccountType { get; set; }
        public CurrencyType Currency { get; set; }
        public int ClientId { get; set; }
    }
}