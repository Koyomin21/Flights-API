using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights.Application.Flights.Commands;
using Flights.Application.Flights.Common;
using Flights.Application.Flights.Queries;
using Flights.Contracts.Flights;
using Mapster;

namespace Flights.Api.Common.Mapping;

public class FlightsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetFlightsRequest, GetFlightsQuery>();
        config.NewConfig<FlightResult, FlightDTO>()
        .Map(dest => dest.Departure, src => src.Departure.ToString())
        .Map(dest => dest.Arrival, src => src.Arrival.ToString());

        config.NewConfig<CreateFlightsRequest, CreateFlightCommand>()
        .IgnoreNullValues(true);

        config.NewConfig<(int id, UpdateFlightStatusRequest request), UpdateFlightStatusCommand>()
        .Map(dest => dest.Id, src => src.id)
        .Map(dest => dest.Status, src => src.request.Status);
    }
}