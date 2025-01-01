using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Application.Flights.Common;
using MediatR;

namespace Flights.Application.Flights.Queries;

public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, IEnumerable<FlightResult>>
{
    private readonly IFlightRepository _flightRepository;

    public GetFlightsQueryHandler(IFlightRepository flightRepository) 
    {
        _flightRepository = flightRepository;
    }


    public async Task<IEnumerable<FlightResult>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
    {
        var flights = await _flightRepository.GetFlightsByDestinationAndOrOrigin(request.Destination, request.Origin);

        return flights.Select(f => 
                        new FlightResult
                        (
                            f.Origin, 
                            f.Destination, 
                            f.Departure, 
                            f.Arrival,
                            f.Status.ToString()
                        ));
    }
}