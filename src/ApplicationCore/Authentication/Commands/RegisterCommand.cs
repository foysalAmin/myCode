using ApplicationCore.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Authentication.Commands;

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
