using Flights.Domain.Entities;
using Flights.Infrastructure.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.SqlServer;

public class ApplicationDbContext: DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {}

    public DbSet<User> Users { get; set; } 
    public DbSet<Role> Roles { get; set; } 
    public DbSet<Flight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureRole();
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureFlight();
    }

}