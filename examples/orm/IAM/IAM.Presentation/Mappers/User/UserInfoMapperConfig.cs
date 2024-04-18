using IAM.Contracts.User;
using Mapster;

namespace IAM.Presentation.Mappers.User;

public class UserInfoMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<IAM.Domain.User, UserInfoResponse>();
    }
}