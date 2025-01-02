using Flights.Domain.Entities;
using Flights.Domain.Enums;

namespace Flights.Application.Common.Interfaces.SqlServer;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetFlightsByDestinationAndOrOrigin(string? destination, string? origin); 
    Task<Flight?> GetFlight(int id);
    Task AddFlight(Flight flight);
    Task UpdateFlightStatus(int id, FlightStatus status);
}
