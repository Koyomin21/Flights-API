using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights.Contracts.Flights;

public record GetFlightsRequest(
    string Origin,
    string Destination
);
