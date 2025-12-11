using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class DepositMoneyCommand : IRequest<AccountUpdateDto>
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}