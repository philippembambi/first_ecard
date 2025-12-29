using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using First.Ecard.Application.Features.Agents.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

            Response.Cookies.Append("auth_token", result.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(8)
            });
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                FullName = User.Identity!.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value
            });
        }

        [HttpGet("logout")]
        public IActionResult Loggout()
        {
            Response.Cookies.Delete("auth_token");
            return Ok();
        }
    }
}