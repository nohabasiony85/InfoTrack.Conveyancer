using InfoTrack.Conveyancer.Domain.Models;

namespace InfoTrack.Conveyancer.Domain.Repositories;

public interface ISettlementRepository
{
    public Task<SettlementBooking?> GetSettlementByHour(int hour);
    Task<Guid> CreateSettlement(BookingTime requestBookingTime, string requestName);
}