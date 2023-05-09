using Flights.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services) 
    {
        services.AddControllers();
        services.AddMappings();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });


        return services;
    }
}