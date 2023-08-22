using FluentValidation;
using InfoTrack.Conveyancer.Domain.Exceptions;
using InfoTrack.Conveyancer.Domain.Repositories;
using InfoTrack.Conveyancer.Domain.Validators;
using MediatR;

namespace InfoTrack.Conveyancer.Domain.Models.Handlers;

public record CreateReservationCommand(BookingTime BookingTime, string Name) : IRequest<Guid>;

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

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly ISettlementRepository _repository;

    public CreateReservationCommandHandler(ISettlementRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var existingBooking = await _repository.GetSettlementByHour(request.BookingTime.Hour);
        if (existingBooking != null)
        {
            throw new BookingConflictException(); //TODO: send existing booking Id
        }

        var bookingId = await _repository.CreateSettlement(request.BookingTime, request.Name);
        
        return await Task.FromResult(bookingId);
    }
}

