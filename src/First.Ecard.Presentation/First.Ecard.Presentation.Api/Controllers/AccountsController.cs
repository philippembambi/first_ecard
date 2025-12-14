using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using First.Ecard.Application.Features.Accounts.Commands;
using First.Ecard.Application.Features.Accounts.Queries;
using First.Ecard.Application.Dtos;

namespace First.Ecard.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        } 

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAccountQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAccountByIdQuery(id));
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, AccountUpdateDto accountUpdateDto)
        {
            accountUpdateDto.AccountId = id;
            var result = await _mediator.Send(new UpdateAccountStatusCommand(accountUpdateDto));
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAccountCommand(id));
            return NoContent();
        }

        [HttpPut("{id:int}/deposit/{amount:decimal}")]
        public async Task<IActionResult> MakeDeposit(int id, decimal amount)
        {
            await _mediator.Send(new DepositMoneyCommand(id, amount));
            return NoContent();
        }

        [HttpPut("{id:int}/withdraw/{amount:decimal}")]
        public async Task<IActionResult> MakeWithdraw(int id, decimal amount)
        {
            await _mediator.Send(new WithdrawMoneyCommand(id, amount));
            return NoContent();
        }
    }
}