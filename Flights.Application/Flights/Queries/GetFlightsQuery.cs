using Flights.Application.Flights.Common;
using MediatR;

namespace Flights.Application.Flights.Queries;

public record GetFlightsQuery(
    string Origin,
    string Destination
): IRequest<IEnumerable<FlightResult>>;