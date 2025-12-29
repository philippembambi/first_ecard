using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Accounts.Commands
{
    public class DepositMoneyCommandValidator : AbstractValidator<DepositMoneyCommand>
    {
        public DepositMoneyCommandValidator()
        {
            RuleFor(x => x.Dto.AccountId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Dto.Balance)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }
}