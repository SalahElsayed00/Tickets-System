using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Application.Queries.GetAll.Validator
{
    internal class GetAllTicketsQueryValidator : AbstractValidator<GetAllTicketsQuery>
    {
        public GetAllTicketsQueryValidator()
        {
            RuleFor(x => x.PageSize).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Page).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
