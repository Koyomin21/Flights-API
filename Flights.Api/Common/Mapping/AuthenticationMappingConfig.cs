using Flights.Application.Authentication.Commands.Register;
using Flights.Application.Authentication.Common;
using Flights.Application.Authentication.Queries.Login;
using Flights.Application.Flights.Queries;
using Flights.Application.Flights.Queries.Common;
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

        config.NewConfig<GetFlightsRequest, GetFlightsQuery>();
        config.NewConfig<FlightResult, FlightDTO>()
        .Map(dest => dest.Departure, src => src.Departure.ToString())
        .Map(dest => dest.Arrival, src => src.Arrival.ToString());

    }
}