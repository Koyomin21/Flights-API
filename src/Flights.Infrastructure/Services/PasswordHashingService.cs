using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights.Application.Common.Services;

namespace Flights.Infrastructure.Services;

public class PasswordHashingService : IPasswordHashingService
{
    public string GetPasswordHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool IsPasswordVerified(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}