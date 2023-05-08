using Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.SqlServer.Configurations
{
    public static class FlightConfiguration
    {
        public static void ConfigureFlight(this ModelBuilder builder)
        {
            builder.Entity<Flight>().ToTable("Flight");

            builder.Entity<Flight>()
                .Property(f => f.Origin)
                .HasMaxLength(256);

            builder.Entity<Flight>()
                .Property(f => f.Destination)
                .HasMaxLength(256);

            builder.Entity<Flight>()
                .Property(f => f.Status)
                .HasConversion<int>();
        }
    }
}