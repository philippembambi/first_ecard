using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class WithdrawMoneyCommandValidator : AbstractValidator<WithdrawMoneyCommand>
    {
        public WithdrawMoneyCommandValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty()
                .NotNull();
            
            RuleFor(x => x.Balance)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }
}