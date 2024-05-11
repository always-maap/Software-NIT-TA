using IAM.Domain;

namespace IAM.Application.UserService;

public interface IUserInfoService
{
    Task<User> Handle();
}