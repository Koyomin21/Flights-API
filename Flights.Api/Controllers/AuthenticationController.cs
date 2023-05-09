using Flights.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Flights.Application.Authentication.Commands.Register;
using Flights.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace Flights.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator, IMapper mapper) 
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Route("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var result = await _mediator.Send(command);

        return Ok(_mapper.Map<AuthenticationResponse>(result));
    }

    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var result = await _mediator.Send(query);

        return Ok(_mapper.Map<AuthenticationResponse>(result));
    }
}