using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using First.Ecard.Application.Dtos;
using First.Ecard.Domain.Entities;
using First.Ecard.Application.Interfaces;
using AutoMapper;
using First.Ecard.Application.Features.Accounts.Queries;

namespace First.Ecard.Application.Features.Accounts.Handlers
{
    public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, List<AccountDto>>
    {
        public readonly IAccountRepository _accountRepository;
        public readonly IMapper _mapper;

        public GetAllAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<List<AccountDto>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAllWithClientAsync();
            return _mapper.Map<List<AccountDto>>(accounts);
        }
        
    }
}