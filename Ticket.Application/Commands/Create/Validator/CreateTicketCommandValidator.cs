using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Application.Commands.Create.Validator
{
    public class CreateTicketCommandValidator: AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x => x.Governorate).NotEmpty().NotNull();
            RuleFor(x => x.City).NotEmpty().NotNull();
            RuleFor(x => x.District).NotEmpty().NotNull();
        }
    }
}
