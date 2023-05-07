namespace Flights.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(1, username, password, "token");
    }

    public AuthenticationResult Register(string username, string password)
    {
        return new AuthenticationResult(2, username, password, "token");
    }
}

