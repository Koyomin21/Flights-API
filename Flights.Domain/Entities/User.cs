using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights.Domain.Common.Models;

namespace Flights.Domain.Entities;

public class User : Entity
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
