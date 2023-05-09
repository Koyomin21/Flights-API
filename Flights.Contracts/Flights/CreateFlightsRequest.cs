using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights.Contracts.Flights;

public record CreateFlightsRequest(
    string Origin,
    string Destination,
    string Departure,
    string Arrival,
    string Status
);
