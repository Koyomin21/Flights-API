using System.Net;
using Flights.Application.Common.Errors;

namespace Flights.Application.Authentication.Common.Errors;

public class DuplicateUsernameException : Exception, IUserDefinedException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists";
}
