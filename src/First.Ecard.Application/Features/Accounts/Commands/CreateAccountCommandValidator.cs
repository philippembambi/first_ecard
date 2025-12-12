using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.AccountType)
                .IsInEnum();
            
            RuleFor(x => x.ClientId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Currency)
                .IsInEnum();
        }
    }
}