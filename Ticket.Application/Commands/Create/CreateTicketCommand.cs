using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Entities;
using Ticket.Core.IRepository;

namespace Ticket.Application.Commands.Create
{
    public class CreateTicketCommand : IRequest<int>
    {
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly IRepository<Tickket> _repository;

        public CreateTicketCommandHandler(IRepository<Tickket> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Tickket
            {
                CreationDateTime = DateTime.UtcNow,
                PhoneNumber = request.PhoneNumber,
                Governorate = request.Governorate,
                City = request.City,
                District = request.District,
                Status = "New"
            };

            await _repository.AddAsync(ticket);
            return ticket.Id;
        }
    }

}
