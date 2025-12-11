using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class DeleteAccountCommand : IRequest<AccountDto>
    {
        public int AccountId {get; set;}
    }
}