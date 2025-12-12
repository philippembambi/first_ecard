using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class DepositMoneyCommand : IRequest<DepositMoneyDto>
    {
        public DepositMoneyDto Dto {get;}
        public DepositMoneyCommand(DepositMoneyDto dto)
        {
            Dto = dto;
        }
    }
}