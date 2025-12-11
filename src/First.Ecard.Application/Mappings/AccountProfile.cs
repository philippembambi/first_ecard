using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Accounts.Commands;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountCreateDto, Account>();
            CreateMap<CreateAccountCommand, Account>();
            CreateMap<Account, AccountDto>();
            CreateMap<AccountUpdateDto, Account>();
        }
    }
}