namespace Flights.Application.Authentication.Common;

public record AuthenticationResult
(
    int Id,
    string Username,
    string Token
);
