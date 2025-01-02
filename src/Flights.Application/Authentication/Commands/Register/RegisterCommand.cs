using Flights.Application.Authentication.Common;
using MediatR;

namespace Flights.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string Password
) : IRequest<AuthenticationResult>;
