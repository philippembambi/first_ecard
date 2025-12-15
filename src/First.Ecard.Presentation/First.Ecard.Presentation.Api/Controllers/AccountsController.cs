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

        [HttpPut("update_status")]
        public async Task<IActionResult> Update(AccountUpdateDto accountUpdateDto)
        {
            var result = await _mediator.Send(new UpdateAccountStatusCommand(accountUpdateDto));
            return Ok(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAccountCommand(id));
            return NoContent();
        }

        [HttpPut("deposit")]
        public async Task<IActionResult> MakeDeposit(DepositMoneyDto depositMoneyDto)
        {
            var result = await _mediator.Send(new DepositMoneyCommand(depositMoneyDto));
            return Ok(result);
        }

        [HttpPut("withdraw")]
        public async Task<IActionResult> MakeWithdraw(WithdrawMoneyDto withdrawMoneyDto)
        {
            var result = await _mediator.Send(new WithdrawMoneyCommand(withdrawMoneyDto));
            return Ok(result);
        }

        [HttpGet("client/{client_id:int}")]
        public async Task<IActionResult> GetAllByClientId(int client_id)
        {
            var result = await _mediator.Send(new GetAllAccountByClientIdQuery(client_id));
            return Ok(result);
        }

        [HttpGet("{account_number}")]
        public async Task<IActionResult> GetByAccountNumber(string account_number)
        {
            var result = await _mediator.Send(new GetAccountByAccountNumberQuery(account_number));
            return Ok(result);
        }
    }
}