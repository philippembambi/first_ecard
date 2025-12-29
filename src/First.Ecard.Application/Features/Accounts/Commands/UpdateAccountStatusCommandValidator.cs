using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class UpdateAccountStatusCommandValidator : AbstractValidator<UpdateAccountStatusCommand>
    {
        public UpdateAccountStatusCommandValidator()
        {
            RuleFor(x => x.Dto.Status)
                .IsInEnum();
        }
    }
}