namespace Flights.Contracts.Flights;

public record CreateFlightsRequest(
    string Origin,
    string Destination,
    string Departure,
    string Arrival,
    string Status
);
