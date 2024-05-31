using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket.Application.Commands;
using Ticket.Application.Commands.Create;
using Ticket.Application.Commands.Update;
using Ticket.Application.Queries;
using Ticket.Application.Queries.GetAll;
using Ticket.Application.Queries.GetById;

namespace Tickets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            var ticketId = await _mediator.Send(command);
            return Ok(ticketId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var query = new GetTicketByIdQuery { Id = id };
            var ticket = await _mediator.Send(query);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var query = new GetAllTicketsQuery { Page = page, PageSize = pageSize };
            var tickets = await _mediator.Send(query);
            return Ok(tickets);
        }

        [HttpPut("{id}/handle")]
        public async Task<IActionResult> HandleTicket(int id)
        {
            var command = new UpdateTicketCommand { Id = id, Status = "Handled" };
            await _mediator.Send(command);
            return Ok();
        }
    }

}
