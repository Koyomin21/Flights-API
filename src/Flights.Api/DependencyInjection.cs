using Flights.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

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

        services.AddSwagger();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services) 
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => 
        { 
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "JSON Web Token based security",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
        return services;
    }
}