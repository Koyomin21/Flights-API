using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights.Contracts.Flights;

public record FlightDTO(
    int Id,
    string Origin,
    string Destination,
    string Arrival,
    string Departure,
    string Status
);
