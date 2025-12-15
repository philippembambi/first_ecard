using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Dtos;
using MediatR;

namespace First.Ecard.Application.Features.Accounts.Queries
{
    public record GetAllAccountByClientIdQuery(int ClientId) : IRequest<List<AccountDto>>;
}