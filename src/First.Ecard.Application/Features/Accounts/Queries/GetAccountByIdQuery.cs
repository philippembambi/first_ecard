using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Queries
{
    public class GetAccountByIdQuery : IRequest<AccountDto>
    {
         public int AccountId { get; set; }
    }
}