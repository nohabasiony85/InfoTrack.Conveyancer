namespace InfoTrack.Conveyancer.Domain.Models;

public class SettlementBooking
{
    public Guid Id { get; set; }
    public TimeOnly BookingTime { get; set; }
    public string Name { get; set; }
}