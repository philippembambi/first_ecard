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
    public class DepositMoneyCommandHandler : IRequestHandler<DepositMoneyCommand, DepositMoneyDto>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public DepositMoneyCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<DepositMoneyDto> Handle(DepositMoneyCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var account = await _accountRepository.GetByIdAsync(dto.AccountId) ?? throw new FirstValidationException("Not found", new[] {"Account not found"});
            
            if(dto.Balance <= 0)
                throw new FirstValidationException("Invalid Amount", new[] {"Amount must be > 0"});
            
            account.Balance += dto.Balance;
            account.CreatedAt = DateTime.UtcNow;

            await _accountRepository.UpdateAsync(account);
            
            return _mapper.Map<DepositMoneyDto>(account);
        }
    }
}