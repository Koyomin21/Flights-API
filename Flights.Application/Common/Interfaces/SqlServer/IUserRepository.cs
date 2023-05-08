using Flights.Domain.Entities;

namespace Flights.Application.Common.Interfaces.SqlServer;

public interface IUserRepository
{
    User? GetUserByUsername(string username);
    void Add(User user);   
}
