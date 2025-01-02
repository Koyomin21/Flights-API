using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights.Contracts.Authentication;

public record RegisterRequest(
    string Username,
    string Password   
);
