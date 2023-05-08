using Flights.Application.Authentication.Common;
using Flights.Application.Common.Interfaces.Authentication;
using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Application.Common.Services;
using Flights.Domain.Entities;
using MediatR;

namespace Flights.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashingService _passwordHashingService;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHashingService passwordHashingService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHashingService = passwordHashingService;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByUsername(request.Username) is not null) 
        {
            throw new Exception("Duplicate Username Error!");
        }

        var user = new User
        {
            Username = request.Username,
            Password = _passwordHashingService.GetPasswordHash(request.Password), // convert to hash
            RoleId = 1
        };

        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username);

        return new AuthenticationResult(user.Id, user.Username, token);
    }
}
