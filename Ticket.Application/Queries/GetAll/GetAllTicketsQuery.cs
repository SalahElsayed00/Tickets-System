using MediatR;
using Ticket.Core.Entities;
using Ticket.Core.IRepository;

namespace Ticket.Application.Queries.GetAll
{
    public class GetAllTicketsQuery : IRequest<IEnumerable<Tickket>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }

    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<Tickket>>
    {
        private readonly IRepository<Tickket> _repository;

        public GetAllTicketsQueryHandler(IRepository<Tickket> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tickket>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllAsync(request.Page, request.PageSize);

    }

}
