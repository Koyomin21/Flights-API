using Flights.Application.Authentication.Commands.Register;
using Flights.Application.Authentication.Common;
using Flights.Application.Authentication.Queries.Login;
using Flights.Application.Flights.Common;
using Flights.Application.Flights.Queries;
using Flights.Contracts.Authentication;
using Flights.Contracts.Flights;
using Mapster;

namespace Flights.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest.Token, src => src.Token)
        .Map(dest => dest, src => src.User);
    }
}