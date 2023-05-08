using Flights.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Flights.Application.Authentication.Commands.Register;
using Flights.Application.Authentication.Queries.Login;

namespace Flights.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController: ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator) 
    {
        _mediator = mediator;
    }

    [Route("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Username, request.Password);
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Username, request.Password);
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}