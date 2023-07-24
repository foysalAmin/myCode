using ApplicationCore.Authentication.Common;
using ApplicationCore.Common.Interfaces.Authentication;
using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Authentication.Commands;

public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(command.Email) is not null)
        {
            return Errors.User.DublicateEmail;
        }

        User user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);

        await _userRepository.AddAsync(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
