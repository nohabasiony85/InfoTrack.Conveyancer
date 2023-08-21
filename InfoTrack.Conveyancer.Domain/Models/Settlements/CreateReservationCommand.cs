using FluentValidation;
using InfoTrack.Conveyancer.Domain.Validators;
using MediatR;

namespace InfoTrack.Conveyancer.Domain.Models.Settlements;

public record CreateReservationCommand(TimeOnly BookingTime, string Name) : IRequest<bool>;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.BookingTime)
            .NotNull()
            .NotEmpty()
            .SetValidator(new BookingTimeValidator());
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
    }
}

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, bool>
{
    public async Task<bool> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        
        return await Task.FromResult(false);
    }
}

