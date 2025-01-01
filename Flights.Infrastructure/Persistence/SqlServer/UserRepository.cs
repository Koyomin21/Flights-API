using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.Persistence.SqlServer;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) 
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        _context.Users.Add(user);
        await _context.Entry(user).Reference(u => u.Role).LoadAsync();
        await _context.SaveChangesAsync();
    }

    public Task<User?> GetUserByUsername(string username)
    {
        return _context.Users.Include(u => u.Role).Where(u => u.Username == username).FirstOrDefaultAsync();
    }
}