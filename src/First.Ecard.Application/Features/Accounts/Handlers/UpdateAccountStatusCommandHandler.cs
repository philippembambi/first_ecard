using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Exceptions;
using First.Ecard.Application.Features.Accounts.Commands;
using First.Ecard.Application.Interfaces;
using First.Ecard.Domain.Entities;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Handlers
{
    public class UpdateAccountStatusCommandHandler : IRequestHandler<UpdateAccountStatusCommand, AccountUpdateDto>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IAppLogger<Account> _logger;

        public UpdateAccountStatusCommandHandler(IMapper mapper, IAccountRepository accountRepository, IAppLogger<Account> logger)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<AccountUpdateDto> Handle(UpdateAccountStatusCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var account = await _accountRepository.GetByIdAsync(dto.AccountId) ?? throw new FirstValidationException("Not found", new[] {"Account not found"});
            
            if(dto.Status.HasValue)
                account.Status = (Domain.Enums.AccountStatus)dto.Status;
                account.UpdatedAt = DateTime.UtcNow;
            await _accountRepository.UpdateAsync(account);
            
            return dto;
        }
    }
}