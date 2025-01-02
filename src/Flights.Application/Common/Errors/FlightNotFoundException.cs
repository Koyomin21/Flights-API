using System.Net;

namespace Flights.Application.Common.Errors;

public class FlightNotFoundException : Exception, IUserDefinedException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "Flight Not Found!";
}
