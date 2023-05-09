using Flights.Domain.Entities;

namespace Flights.Application.Common.Interfaces.SqlServer;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetFlightsByDestinationAndOrOrigin(string? destination, string? origin); 
}
