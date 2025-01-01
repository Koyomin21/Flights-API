using Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.Persistence.SqlServer.Configurations
{
    public static class UserConfiguration
    {
        public static void ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(256);

            builder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(256);
                
            builder.Entity<User>()
                .HasOne(u => u.Role);
        }
    }
}