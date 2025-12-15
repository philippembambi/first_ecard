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
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, AccountDto>
    {
        private readonly IGenericRepository<Account> _accountRepository;
        private readonly IMapper _mapper;

        public DeleteAccountCommandHandler(IGenericRepository<Account> accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountId) ?? throw new FirstValidationException("Not found", new[] {"Account does not exist"});
            await _accountRepository.DeleteAsync(account);
            return  _mapper.Map<AccountDto>(account);
        }
    }
}