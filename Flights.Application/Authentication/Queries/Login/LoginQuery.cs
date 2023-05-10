using Flights.Application.Authentication.Common;
using MediatR;

namespace Flights.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Username,
    string Password
) : IRequest<AuthenticationResult>;
