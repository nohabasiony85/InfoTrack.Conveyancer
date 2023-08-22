using InfoTrack.Conveyancer.Domain.Models;

namespace InfoTrack.Conveyancer.Domain.Repositories;

public class SettlementRepository : ISettlementRepository
{
    private readonly ConveyancerDataContext _context;

    public SettlementRepository(ConveyancerDataContext context)
    {
        _context = context;
        SeedData.Initialize();
    }

    public async Task<List<SettlementBooking?>> GetSettlements()
    {
        return await Task.FromResult(_context.SettlementBookings
            .ToList());
    }

    public async Task<SettlementBooking?> GetSettlementByHour(int hour)
    {
        return await Task.FromResult(
            _context.SettlementBookings.FirstOrDefault(b => b != null && b.BookingTimeHour == hour));
    }

    public async Task<Guid> CreateSettlement(BookingTime requestBookingTime, string requestName)
    {
        var newId = Guid.NewGuid();
        _context.SettlementBookings.Add(new SettlementBooking()
        {
            Id = newId,
            BookingTimeHour = requestBookingTime.Hour,
            BookingTimeMinute = requestBookingTime.Minute,
            Name = requestName
        });
        await _context.SaveChangesAsync();
        return newId;
    }
}