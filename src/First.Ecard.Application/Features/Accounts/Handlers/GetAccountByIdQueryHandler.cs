using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Interfaces;
using MediatR;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Features.Accounts.Queries;

namespace First.Ecard.Application.Features.Accounts.Handlers
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
    {
        public readonly IGenericRepository<Account> _accountRepository;
        public readonly IMapper _mapper;

        public GetAccountByIdQueryHandler(IGenericRepository<Account> accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountId); 
            return _mapper.Map<AccountDto>(account);           
        }
    }
}