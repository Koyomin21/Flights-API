namespace Flights.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator 
{
    string GenerateToken(int userId, string username, string roleCode);
}