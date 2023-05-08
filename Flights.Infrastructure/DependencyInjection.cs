using Flights.Application.Common.Interfaces.Authentication;
using Flights.Application.Common.Services;
using Flights.Infrastructure.Authentication;
using Flights.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Flights.Infrastructure.Services.Authentication;
using Flights.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Flights.Application.Common.Interfaces.SqlServer;

namespace Flights.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration) 
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPasswordHashingService, PasswordHashingService>();

        services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(
            configuration.GetConnectionString("MainConnectionString"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name)
        ));
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}