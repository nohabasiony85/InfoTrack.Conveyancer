using InfoTrack.Conveyancer.Domain.Models;

namespace InfoTrack.Conveyancer.Domain.Repositories;

public interface ISettlementRepository
{
    public Task<List<SettlementBooking?>> GetSettlements();
    public Task<SettlementBooking?> GetSettlementByHour(int hour);
    Task<Guid> CreateSettlement(TimeOnly requestBookingTime, string requestName);
}