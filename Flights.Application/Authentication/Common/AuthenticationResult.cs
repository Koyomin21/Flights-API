using Flights.Domain.Entities;

namespace Flights.Application.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token
);
