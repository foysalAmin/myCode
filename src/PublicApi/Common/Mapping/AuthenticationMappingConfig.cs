using Application.Authentication.Queries.Login;
using ApplicationCore.Authentication.Commands;
using ApplicationCore.Authentication.Common;
using Contracts.Authentication;
using Mapster;

namespace PublicApi.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegistrationRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}
