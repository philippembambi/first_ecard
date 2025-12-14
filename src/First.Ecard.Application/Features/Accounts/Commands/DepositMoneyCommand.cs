using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public record DepositMoneyCommand(int AccountId, decimal Balance) : IRequest<DepositMoneyDto>;
}