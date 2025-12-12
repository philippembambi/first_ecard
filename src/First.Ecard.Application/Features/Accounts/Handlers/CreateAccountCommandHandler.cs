using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Interfaces;
using AutoMapper;
using First.Ecard.Application.Features.Accounts.Commands;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Features.Accounts.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountDto>
    {
        public readonly IGenericRepository<Account> _accountRepository;
        public readonly IMapper _mapper;

        public CreateAccountCommandHandler(IGenericRepository<Account> accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request);
            
            account.CreatedAt = DateTime.UtcNow;
            account.Balance = 0.0m;
            account.Status = AccountStatus.Active;
            account.AccountNumber = Account.GenerateAccountNumber();
            account.CreatedAt = DateTime.UtcNow;

            await _accountRepository.CreateAsync(account);
            return _mapper.Map<AccountDto>(account);
        }
    }
}