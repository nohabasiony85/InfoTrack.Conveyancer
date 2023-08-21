namespace InfoTrack.Conveyancer.API.Models;

public class CreateReservationRequest
{
    public BookingTime BookingTime { get; init; }
    public string Name { get; init; }
}

public class BookingTime
{
    public int Hours { get; init; }
    public int Minutes { get; set; }
}