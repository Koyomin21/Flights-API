namespace Flights.Contracts.Flights;

public record FlightDTO(
    int Id,
    string Origin,
    string Destination,
    string Arrival,
    string Departure,
    string Status
);
