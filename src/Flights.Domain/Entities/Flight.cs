using Flights.Domain.Common.Models;
using Flights.Domain.Enums;

namespace Flights.Domain.Entities;

public class Flight : Entity
{
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTimeOffset Departure { get; set; }
    public DateTimeOffset Arrival { get; set; }
    public FlightStatus Status { get; set; }

}
