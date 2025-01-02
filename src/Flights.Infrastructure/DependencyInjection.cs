using Flights.Application.Common.Interfaces.Authentication;
using Flights.Application.Common.Services;
using Flights.Infrastructure.Authentication;
using Flights.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Flights.Infrastructure.Services.Authentication;
using Flights.Infrastructure.Persistence.SqlServer;
using Microsoft.EntityFrameworkCore;
using Flights.Application.Common.Interfaces.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Flights.Infrastructure.Persistence;

namespace Flights.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddAuth(configuration);
        services.AddPersistence(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPasswordHashingService, PasswordHashingService>();
        

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o => 
            {
                var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        return services;
    }

    private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var persistenceOptions = new PersistenceOptions();
        configuration.Bind(PersistenceOptions.SectionName, persistenceOptions);
        services.AddSingleton(Options.Create(persistenceOptions));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                connectionString: persistenceOptions.ConnectionString,
                sqlServerOptionsAction: sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name);
                }
            );
        });
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
    }

}