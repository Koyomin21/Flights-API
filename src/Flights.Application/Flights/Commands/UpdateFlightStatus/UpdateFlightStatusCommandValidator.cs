using Flights.Domain.Enums;
using FluentValidation;

namespace Flights.Application.Flights.Commands.UpdateFlightStatus;

public class UpdateFlightStatusCommandValidator : AbstractValidator<UpdateFlightStatusCommand>
{
    public UpdateFlightStatusCommandValidator()
    {
        RuleFor(f => f.Id).NotEmpty().GreaterThan(0);
        RuleFor(f => f.Status)
        .NotEmpty()
        .Must(s => Enum.GetNames(typeof(FlightStatus)).Contains(s))
        .WithMessage("Invalid Status");
        
    }
}