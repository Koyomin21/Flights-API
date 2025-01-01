using Flights.Application.Flights.Common;
using MediatR;

namespace Flights.Application.Flights.Commands.UpdateFlightStatus;

public record UpdateFlightStatusCommand(
    int Id,
    string Status
): IRequest<FlightResult>;