using Application.Authentication.Queries.Login;
using ApplicationCore.Authentication.Commands;
using ApplicationCore.Authentication.Common;
using Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PublicApi.Controller;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> registerErrorsResult = await _mediator.Send(command);

        return registerErrorsResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> authErrorsResult = await _mediator.Send(query);

        return authErrorsResult.IsError && authErrorsResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials
            ? Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authErrorsResult.FirstError.Description)
            : authErrorsResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}
