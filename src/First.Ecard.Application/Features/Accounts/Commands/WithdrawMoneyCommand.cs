using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public record WithdrawMoneyCommand(int AccountId, decimal Balance) : IRequest<WithdrawMoneyDto>;
}