using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Domain.Entities;

namespace Flights.Infrastructure.SqlServer;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) 
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetUserByUsername(string username)
    {
        return _context.Users.Where(u => u.Username == username).FirstOrDefault();
    }
}