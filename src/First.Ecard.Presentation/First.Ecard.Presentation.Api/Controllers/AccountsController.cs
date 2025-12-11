using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using First.Ecard.Application.Features.Accounts.Commands;
using First.Ecard.Application.Features.Accounts.Queries;

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
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
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
    }
}