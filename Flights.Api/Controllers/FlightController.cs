using Flights.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Flights.Application.Authentication.Commands.Register;
using Flights.Application.Authentication.Queries.Login;
using Microsoft.AspNetCore.Authorization;

namespace Flights.Api.Controllers;

[ApiController]
[Route("api/flights")]
[Authorize(Roles = "Moderator")]
public class FlightController: ControllerBase
{
    private readonly IMediator _mediator;

    public FlightController(IMediator mediator) 
    {
        _mediator = mediator;
    }

    [Route("test")]
    public IActionResult Test() {
        return Ok("Success");
    }

    
}