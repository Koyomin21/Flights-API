using System.Net;

namespace Flights.Application.Common.Errors;

public class DuplicateUsernameException : Exception, IUserDefinedException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Username already exists";
}
