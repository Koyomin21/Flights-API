using Flights.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Api.Controllers;


public class ErrorController : ControllerBase
{
    
    [Route("/error")]
    public IActionResult Error() 
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IUserDefinedException ex => ((int)ex.StatusCode, ex.ErrorMessage),
            ValidationException ex => (StatusCodes.Status400BadRequest, ex.ValidationErrors),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
        };

        return Problem(statusCode: statusCode, title: message);
    }
}
