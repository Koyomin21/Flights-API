using Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.SqlServer.Configurations
{
    public static class RoleConfiguration
    {
        public static void ConfigureRole(this ModelBuilder builder)
        {
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<Role>().HasIndex(u => u.Code).IsUnique();
            List<Role> roles = new List<Role>()
            {
                new Role(1, "Moderator"),
                new Role(2, "Client"),
            };

            builder.Entity<Role>().HasData(roles);
        }
    }
}