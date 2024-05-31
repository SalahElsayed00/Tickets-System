using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Entities;
using Ticket.Core.IRepository;

namespace Ticket.Application.Queries.GetById
{
    public class GetTicketByIdQuery : IRequest<Tickket>
    {
        public int Id { get; set; }
    }

    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Tickket>
    {
        private readonly IRepository<Tickket> _repository;

        public GetTicketByIdQueryHandler(IRepository<Tickket> repository)
        {
            _repository = repository;
        }

        public async Task<Tickket> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetByIdAsync(request.Id);

    }

}
