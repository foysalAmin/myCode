using Domain.UserAggregate;

namespace ApplicationCore.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
