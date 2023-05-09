using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Domain.Entities;
using Flights.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.SqlServer;

public class FlightRepository : IFlightRepository
{
    private readonly ApplicationDbContext _context;

    public FlightRepository(ApplicationDbContext context) 
    {
        _context = context;
    }

    public async Task AddFlight(Flight flight)
    {
        _context.Add(flight);
        await _context.SaveChangesAsync();
    }

    public async Task<Flight?> GetFlight(int id)
    {
        return await _context.Flights.Where(f => f.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Flight>> GetFlightsByDestinationAndOrOrigin(string? destination, string? origin)
    {
        IQueryable<Flight> flights = _context.Flights;
        if(destination is not null)
        {
            flights = flights.Where(f => f.Destination == destination);
        }

        if(origin is not null)
        {
            flights = flights.Where(f => f.Origin == origin);
        }

        return await flights.OrderBy(f => f.Arrival).ToListAsync();
    }

    public async Task UpdateFlightStatus(int id, FlightStatus status)
    {
        var flight = await _context.Flights.Where(f => f.Id == id).FirstOrDefaultAsync();
        flight.Status = status;
        await _context.SaveChangesAsync();
    }
}