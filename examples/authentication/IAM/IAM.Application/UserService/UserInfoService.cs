using IAM.Application.Common;
using IAM.Domain;

namespace IAM.Application.UserService;

public class UserInfoService : IUserInfoService
{
    private readonly ICurrentUser _currentUser;
    private readonly IUserRepository _userRepository;

    public UserInfoService(ICurrentUser currentUser, IUserRepository userRepository)
    {
        _currentUser = currentUser;
        _userRepository = userRepository;
    }

    public User Handle()
    {
        var phone = _currentUser.GetUserPhone();
        
        var user = _userRepository.GetByPhone(phone);
        
        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }
}