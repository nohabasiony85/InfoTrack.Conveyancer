using InfoTrack.Conveyancer.Domain.Models;

namespace InfoTrack.Conveyancer.API.Models;

public class CreateReservationRequest
{
    public BookingTime BookingTime { get; init; }
    public string Name { get; init; }
}