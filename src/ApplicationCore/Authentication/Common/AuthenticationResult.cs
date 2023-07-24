using Domain.UserAggregate;

namespace ApplicationCore.Authentication.Common;

public record AuthenticationResult(User User, string Token);
