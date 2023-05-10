using Flights.Application.Flights.Common;
using MediatR;

namespace Flights.Application.Flights.Commands;

public record CreateFlightCommand(
    string Origin,
    string Destination,
    DateTimeOffset Departure,
    DateTimeOffset Arrival,
    string Status
): IRequest<FlightResult>;