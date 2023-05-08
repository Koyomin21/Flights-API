using Flights.Application.Authentication.Common;
using Flights.Application.Common.Interfaces.Authentication;
using Flights.Application.Common.Interfaces.SqlServer;
using Flights.Application.Common.Services;
using Flights.Domain.Entities;
using MediatR;

namespace Flights.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashingService _passwordHashingService;


    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHashingService passwordHashingService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHashingService = passwordHashingService;
    }
    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByUsername(request.Username) is not User user) 
        {
            throw new Exception("Invalid Credentials");
        }

        if(!_passwordHashingService.IsPasswordVerified(request.Password, user.Password)) 
        {
            throw new Exception("Invalid Credentials");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username);
        
        return new AuthenticationResult(user.Id, user.Username, token);
    }
}
