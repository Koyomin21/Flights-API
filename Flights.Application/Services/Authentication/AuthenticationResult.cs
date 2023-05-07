namespace Flights.Application.Services.Authentication;

public record AuthenticationResult
(
    int Id,
    string Username,
    string Password,
    string Token
);
