using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using First.Ecard.Application.Features.Accounts.Commands;
using First.Ecard.Application.Features.Accounts.Queries;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Cards.Commands;
using First.Ecard.Application.Features.Cards.Handlers;

namespace First.Ecard.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCardCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCardQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCardByIdQuery(id));
            return Ok(result);
        }
    }
}