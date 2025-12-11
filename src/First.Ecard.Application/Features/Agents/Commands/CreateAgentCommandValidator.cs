using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Agents.Commands
{
    public class CreateAgentCommandValidator : AbstractValidator<CreateAgentCommand>
    {
        public CreateAgentCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);
                
            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.Gender)
                .IsInEnum()
                .WithMessage("Inccorect gender");

            RuleFor(x => x.Role)
                .IsInEnum()
                .WithMessage("Inccorect role");
        }
    }
}