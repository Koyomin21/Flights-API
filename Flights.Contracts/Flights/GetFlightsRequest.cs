namespace Flights.Contracts.Flights;

public record GetFlightsRequest(
    string Origin,
    string Destination
);
