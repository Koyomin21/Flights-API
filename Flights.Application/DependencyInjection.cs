using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using System.Reflection;
using Flights.Application.Common.Behaviours;

namespace Flights.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}