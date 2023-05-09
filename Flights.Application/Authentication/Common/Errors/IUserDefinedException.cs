using System.Net;

namespace Flights.Application.Common.Errors;

public interface IUserDefinedException 
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}