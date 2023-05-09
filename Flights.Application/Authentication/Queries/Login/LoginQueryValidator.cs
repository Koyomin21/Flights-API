using Flights.Application.Authentication.Common;
using FluentValidation;
using MediatR;

namespace Flights.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x=> x.Username).NotEmpty();
        RuleFor(x=> x.Password).NotEmpty();
    }
}
