using MediatR;

namespace InfoTrack.Conveyancer.Domain.Models.Settlements;

public record CreateReservationCommand(string BookingTime, string Name) : IRequest<bool>;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, bool>
{
    public async Task<bool> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(false);
    }
}

