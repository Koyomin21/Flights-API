using Flights.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Flights.Application.Authentication.Commands.Register;
using Flights.Application.Authentication.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using MapsterMapper;
using Flights.Contracts.Flights;
using Flights.Application.Flights.Queries;
using Flights.Application.Flights.Commands;

namespace Flights.Api.Controllers;

[ApiController]
[Route("api/flights")]
[Authorize]
public class FlightController: ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public FlightController(ISender mediator, IMapper mapper) 
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("all")]
    public async Task<IActionResult> GetFlights([FromBody] GetFlightsRequest request) 
    {
        var query = _mapper.Map<GetFlightsQuery>(request);// map object;
        var result = await _mediator.Send(query);

        return Ok(_mapper.Map<List<FlightDTO>>(result));
    }

    [Authorize(Roles = "Moderator")]
    [HttpPost]
    public async Task<IActionResult> CreateFlight([FromBody] CreateFlightsRequest request)
    {
        var command = _mapper.Map<CreateFlightCommand>(request);
        var result = await _mediator.Send(command);

        return Ok(_mapper.Map<FlightDTO>(result));
    }

    [Authorize(Roles = "Moderator")]
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateFlightStatus([FromRoute] int id, [FromBody] UpdateFlightStatusRequest request)
    {
        var command = _mapper.Map<UpdateFlightStatusCommand>((id, request));
        var result = await _mediator.Send(command);

        return Ok(_mapper.Map<FlightDTO>(result));
    }
    
}