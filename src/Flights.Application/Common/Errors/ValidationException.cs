using System.Net;
using FluentValidation.Results;

namespace Flights.Application.Common.Errors;

public class ValidationException: Exception
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ValidationErrors;

    public ValidationException(IEnumerable<ValidationFailure> errors)
    {
        ValidationErrors = string.Join("\n", errors.Select(e => e.ErrorMessage));
    }


    // public ValidationException(IEnumerable<ValidationFailure> failures)
    //     : this()
    // {
    //     Errors = failures
    //         .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
    //         .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    // }
}