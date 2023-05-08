using Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.SqlServer.Configurations
{
    public static class RoleConfiguration
    {
        public static void ConfigureRole(this ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Role");
            builder.Entity<Role>().HasIndex(u => u.Code).IsUnique();
        }
    }
}