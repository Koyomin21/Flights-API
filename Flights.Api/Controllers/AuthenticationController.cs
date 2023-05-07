using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flights.Application.Services.Authentication;
using Flights.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController: ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService) 
    {
        _authenticationService = authenticationService;
    }

    [Route("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(request.Username, request.Password);
        return Ok(result);
    }

    [Route("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Username, request.Password);
        return Ok(result);
    }
}