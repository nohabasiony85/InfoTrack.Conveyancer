using FluentValidation;
using InfoTrack.Conveyancer.Domain.Exceptions;
using InfoTrack.Conveyancer.Domain.Repositories;
using InfoTrack.Conveyancer.Domain.Validators;
using MediatR;

namespace InfoTrack.Conveyancer.Domain.Models.Handlers;

public record CreateBookingCommand(BookingTime BookingTime, string Name) : IRequest<Guid>;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
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

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly ISettlementRepository _repository;

    public CreateBookingCommandHandler(ISettlementRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
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

