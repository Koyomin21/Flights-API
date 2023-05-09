using Flights.Domain.Entities;
using Flights.Domain.Enums;

namespace Flights.Application.Flights.Queries.Common;

public record FlightResult(
    string Origin,
    string Destination,
    DateTimeOffset Departure,
    DateTimeOffset Arrival,
    String Status
);