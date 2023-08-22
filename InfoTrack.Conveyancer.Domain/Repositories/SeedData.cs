using InfoTrack.Conveyancer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoTrack.Conveyancer.Domain.Repositories;

public abstract class SeedData
{
    public static void Initialize()
    {
        using (var context = new ConveyancerDataContext(new DbContextOptions<ConveyancerDataContext>()))
        {
            if (!context.SettlementBookings.Any())
            {
                context.SettlementBookings.AddRange(new List<SettlementBooking>
                {
                    new()
                    {
                        Id = new Guid(),
                        BookingTimeHour = 9,
                        BookingTimeMinute = 30,
                        Name = "Noha"
                    },
                    new()
                    {
                        Id = new Guid(),
                        BookingTimeHour = 10,
                        BookingTimeMinute = 00,
                        Name = "Tom"
                    },
                    new()
                    {
                        Id = new Guid(),
                        BookingTimeHour = 14,
                        BookingTimeMinute = 30,
                        Name = "Bob"
                    },
                });
                context.SaveChanges();
            }
        }
    }
}