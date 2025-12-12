using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Clients.Commands
{
    public class ClientCreateCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public ClientCreateCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(255);
            
            RuleFor(x => x.Gender)
                .IsInEnum()
                .WithMessage("Inccorect Gender");
            
            RuleFor(x => x.Nationality)
                .MaximumLength(255);
            
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            
            RuleFor(x => x.Address)
                .MaximumLength(255);

            RuleFor(x => x.IDCardNumber)
                .NotEmpty()
                .MaximumLength(20);
            
            RuleFor(x => x.IDCardType)
                .IsInEnum()
                .WithMessage("Inccorect ID Type");
        }
    }
}