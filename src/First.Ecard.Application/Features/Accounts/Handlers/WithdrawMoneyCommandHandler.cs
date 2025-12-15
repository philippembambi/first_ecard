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
    public class WithdrawMoneyCommandHandler : IRequestHandler<WithdrawMoneyCommand, WithdrawMoneyDto>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public WithdrawMoneyCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<WithdrawMoneyDto> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.Dto.AccountId) ?? throw new FirstValidationException("Not found", new[] { "Account not found" });

            if (request.Dto.Balance > account.Balance)
                throw new FirstValidationException("Invalid Amount", new[] { "Withdraw amount greater than Balance" });

            account.Balance -= request.Dto.Balance;
            account.CreatedAt = DateTime.UtcNow;

            await _accountRepository.UpdateAsync(account);
            return request.Dto;
        }
    }
}