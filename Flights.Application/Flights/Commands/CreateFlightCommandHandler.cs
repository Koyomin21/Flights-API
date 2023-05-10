using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Application.Flights.Common;
using Flights.Domain.Entities;
using Flights.Domain.Enums;
using MediatR;

namespace Flights.Application.Flights.Commands;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, FlightResult>
{
    private readonly IFlightRepository _flightRepository;

    public CreateFlightCommandHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    public async Task<FlightResult> Handle(CreateFlightCommand command, CancellationToken cancellationToken)
    {
        await _flightRepository.AddFlight(new Flight 
        {
            Origin = command.Origin,
            Destination = command.Destination,
            Departure = command.Departure,
            Arrival = command.Arrival,
            Status = (FlightStatus)Enum.Parse(typeof(FlightStatus), command.Status)
        });

        return new FlightResult(
            command.Origin, 
            command.Destination,
            command.Departure,
            command.Arrival,
            command.Status
        );
    }
}