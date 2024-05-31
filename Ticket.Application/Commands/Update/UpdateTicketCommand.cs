using MediatR;
using Ticket.Core.Entities;
using Ticket.Core.IRepository;

namespace Ticket.Application.Commands.Update
{
    public class UpdateTicketCommand : IRequest<Tickket>
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, Tickket>
    {
        private readonly IRepository<Tickket> _repository;

        public UpdateTicketCommandHandler(IRepository<Tickket> repository)
        {
            _repository = repository;
        }

        public async Task<Tickket> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.Id);
            if (ticket != null)
            {
                ticket.Status = request.Status;
                return await _repository.UpdateAsync(ticket);
            }
            else
                return new Tickket();
        }
    }

}
