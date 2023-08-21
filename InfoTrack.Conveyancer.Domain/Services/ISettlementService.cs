namespace InfoTrack.Conveyancer.Domain.Services;

public interface ISettlementService
{
    Task<string> CheckAndMakeReservation(string bookingTime, string name);
}