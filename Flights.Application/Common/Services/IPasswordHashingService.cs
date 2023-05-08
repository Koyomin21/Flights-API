using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights.Application.Common.Services;
public interface IPasswordHashingService
{
    string GetPasswordHash(string password);
    bool IsPasswordVerified(string password, string hash);
}