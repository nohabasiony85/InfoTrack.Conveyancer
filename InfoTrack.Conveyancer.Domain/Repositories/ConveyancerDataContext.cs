using InfoTrack.Conveyancer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoTrack.Conveyancer.Domain.Repositories;

public class ConveyancerDataContext : DbContext
{
    public ConveyancerDataContext(DbContextOptions<ConveyancerDataContext> options)
        : base(options)
    {
    }

    
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "SettlementDb");
    }
    public virtual DbSet<SettlementBooking?> SettlementBookings { get; set; }
}