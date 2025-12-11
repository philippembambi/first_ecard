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
                .MinimumLength(6)
                .WithMessage("Le mot de passe doit avoir au moins 6 caractères.");

            RuleFor(x => x.Gender)
                .IsInEnum();

            RuleFor(x => x.Role)
                .IsInEnum();
        }
    }
}