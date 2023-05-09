using System.Net;
using Flights.Application.Common.Errors;

namespace Flights.Application.Authentication.Common.Errors;

public class InvalidCredentialsException : Exception, IUserDefinedException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ErrorMessage => "Invalid Credentials!";
}
