using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using First.Ecard.Application.Dtos;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class UpdateAccountCommand : IRequest<AccountDto>
    {
        public AccountTypeEnum AccountType { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
    }
}