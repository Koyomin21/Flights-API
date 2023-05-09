using Flights.Application.Common.Errors;
using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Application.Flights.Common;
using Flights.Domain.Entities;
using Flights.Domain.Enums;
using MediatR;

namespace Flights.Application.Flights.Commands;

public class UpdateFlightStatusCommandHandler : IRequestHandler<UpdateFlightStatusCommand, FlightResult>
{
    private readonly IFlightRepository _flightRepository;

    public UpdateFlightStatusCommandHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    public async Task<FlightResult> Handle(UpdateFlightStatusCommand command, CancellationToken cancellationToken)
    {
        if(await _flightRepository.GetFlight(command.Id) is not Flight flight)
        {
            throw new FlightNotFoundException();
        }

        await _flightRepository.UpdateFlightStatus(command.Id, (FlightStatus)Enum.Parse(typeof(FlightStatus), command.Status));

        return new FlightResult(
            flight.Origin,
            flight.Destination,
            flight.Departure,
            flight.Arrival,
            command.Status
        );
    }
}