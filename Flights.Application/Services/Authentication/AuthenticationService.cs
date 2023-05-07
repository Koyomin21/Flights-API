using Flights.Application.Common.Interfaces.Authentication;

namespace Flights.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) 
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(1, username, password, "token");
    }

    public AuthenticationResult Register(string username, string password)
    {
        int userId = 1;
        var token = _jwtTokenGenerator.GenerateToken(userId, username);
        return new AuthenticationResult(2, username, password, token);
    }
}

