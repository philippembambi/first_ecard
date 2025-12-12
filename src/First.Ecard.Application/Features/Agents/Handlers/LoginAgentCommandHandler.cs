using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Agents.Commands;
using MediatR;
using AutoMapper;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Interfaces;
using First.Ecard.Application.Exceptions;

namespace First.Ecard.Application.Features.Agents.Handlers
{
    public class LoginAgentCommandHandler : IRequestHandler<LoginAgentCommand, LoginResponseDto>
    {
        public readonly IAgentRepository _agentRepository;
        public readonly IPasswordHasher _passwordHasher;
        public readonly IJwtService _jwtService;

        public LoginAgentCommandHandler(IAgentRepository agentRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _agentRepository = agentRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> Handle(LoginAgentCommand request, CancellationToken cancellationToken)
        {
            var agent = await _agentRepository.GetByEmailAsync(request.Email);

            if (agent == null || !_passwordHasher.Verify(agent.PasswordHash, request.PasswordHash))
                throw new FirstValidationException("Authentification failed", new [] { "Email ou mot de passe incorrect." });

            var accessToken = _jwtService.GenerateAccessToken(agent);
            //var refreshToken = _jwtService.GenerateRefreshToken();

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                //RefreshToken = refreshToken,
                FullName = $"{agent.FirstName} {agent.LastName}",
                Role = agent.Role.ToString()
            };
        }
    }
}