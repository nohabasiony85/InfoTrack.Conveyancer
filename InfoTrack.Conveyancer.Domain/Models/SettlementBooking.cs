namespace InfoTrack.Conveyancer.Domain.Models;

public class SettlementBooking
{
    public Guid Id { get; set; }
    public int BookingTimeHour { get; set; }
    public int BookingTimeMinute { get; set; }
    public string Name { get; set; }
}