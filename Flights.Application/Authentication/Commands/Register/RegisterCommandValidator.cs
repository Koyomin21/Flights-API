using Flights.Application.Authentication.Common;
using FluentValidation;
using MediatR;

namespace Flights.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x=> x.Username).NotEmpty();
        RuleFor(x=> x.Password).NotEmpty();
    }
}
