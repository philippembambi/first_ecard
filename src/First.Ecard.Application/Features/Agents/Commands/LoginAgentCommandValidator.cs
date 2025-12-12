using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace First.Ecard.Application.Features.Agents.Commands
{
    public class LoginAgentCommandValidator : AbstractValidator<LoginAgentCommand>
    {
        public LoginAgentCommandValidator()
        {
                RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);
                
            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}