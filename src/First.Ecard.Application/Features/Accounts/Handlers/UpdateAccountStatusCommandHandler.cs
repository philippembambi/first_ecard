using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Exceptions;
using First.Ecard.Application.Features.Accounts.Commands;
using First.Ecard.Application.Interfaces;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Handlers
{
    public class UpdateAccountStatusCommandHandler : IRequestHandler<UpdateAccountStatusCommand, AccountDto>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountStatusCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<AccountDto> Handle(UpdateAccountStatusCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var account = await _accountRepository.GetByIdAsync(dto.AccountId) ?? throw new FirstValidationException("Not found", new[] {"Account not found"});
            
            if(dto.Status.HasValue)
                account.Status = (Domain.Enums.AccountStatus)dto.Status;
                account.UpdatedAt = DateTime.UtcNow;
            
            return _mapper.Map<AccountDto>(account);
        }
    }
}