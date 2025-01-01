namespace Flights.Application.Flights.Common;

public sealed record FlightResult(
    string Origin,
    string Destination,
    DateTimeOffset Departure,
    DateTimeOffset Arrival,
    string Status
);