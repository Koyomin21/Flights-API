using Flights.Application.Flights.Queries.Common;
using MediatR;

namespace Flights.Application.Flights.Queries;

public record GetFlightsQuery(
    string Origin,
    string Destination
): IRequest<IEnumerable<FlightResult>>;