using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Cards.Commands
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.CardType)
                .IsInEnum();
            RuleFor(x => x.ExpiryDate)
                .NotEmpty()
                .NotNull()
                .Must(d => d > DateTime.Now);
        }
    }
}