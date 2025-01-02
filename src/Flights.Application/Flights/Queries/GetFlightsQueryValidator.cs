using FluentValidation;

namespace Flights.Application.Flights.Queries;

public class GetFlightsQueryValidator : AbstractValidator<GetFlightsQuery>
{
    public GetFlightsQueryValidator()
    {
        RuleFor(x => x.Origin)
        .NotEmpty()
        .MaximumLength(256)
        .When(x => !string.IsNullOrEmpty(x.Origin));
        
        RuleFor(x => x.Destination)
        .NotEmpty()
        .MaximumLength(256)
        .When(x => !string.IsNullOrEmpty(x.Destination));
    }
}