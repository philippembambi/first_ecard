using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using First.Ecard.Application.Dtos;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class UpdateAccountStatusCommand : IRequest<AccountUpdateDto>
    {
        public AccountUpdateDto Dto {get;}

        public UpdateAccountStatusCommand(AccountUpdateDto dto)
        {
            Dto = dto;
        }
    }
}