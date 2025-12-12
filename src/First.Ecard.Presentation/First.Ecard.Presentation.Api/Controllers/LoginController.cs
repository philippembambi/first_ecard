using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Application.Features.Agents.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace First.Ecard.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAgentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}