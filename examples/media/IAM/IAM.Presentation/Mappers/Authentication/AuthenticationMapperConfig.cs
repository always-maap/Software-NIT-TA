using IAM.Application.AuthenticationService;
using IAM.Contracts.Authentication;
using Mapster;

namespace IAM.Presentation.Mappers.Authentication;

public class AuthenticationMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}