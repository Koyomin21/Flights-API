using System.Net;

namespace Flights.Application.Common.Errors;

public class InvalidCredentialsException : Exception, IUserDefinedException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ErrorMessage => "Invalid Credentials!";
}
