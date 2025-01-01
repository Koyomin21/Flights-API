using Flights.Domain.Common.Models;

namespace Flights.Domain.Entities;

public class Role : Entity
{
    public string? Code { get; set; }

    public Role(int id, string code) 
    {
        this.Id = id;
        this.Code = code;
    }
}
