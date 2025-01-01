using Flights.Domain.Common.Models;

namespace Flights.Domain.Entities;

public class User : Entity
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
