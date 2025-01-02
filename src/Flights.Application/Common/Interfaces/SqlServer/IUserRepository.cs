using Flights.Domain.Entities;

namespace Flights.Application.Common.Interfaces.SqlServer;

public interface IUserRepository
{
    Task<User?> GetUserByUsername(string username);
    Task Add(User user);   
}
