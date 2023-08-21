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
                        BookingTime = new TimeOnly(09, 30),
                        Name = "Noha"
                    },
                    new()
                    {
                        Id = new Guid(),
                        BookingTime = new TimeOnly(10, 00),
                        Name = "Tom"
                    },
                    new()
                    {
                        Id = new Guid(),
                        BookingTime = new TimeOnly(14, 30),
                        Name = "Bob"
                    },
                });
                context.SaveChanges();
            }
        }
    }
}