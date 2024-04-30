using IAM.Application.Common;

namespace IAM.Application.AuthenticationService;

public class VerifyService : IVerifyService
{
    private readonly IVerifyCodeCacheProvider _cache;
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUser _currentUser;

    public VerifyService(IVerifyCodeCacheProvider cache, IUserRepository userRepository, ICurrentUser currentUser)
    {
        _cache = cache;
        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    public async Task Handle(string code)
    {
        var phone = _currentUser.GetUserPhone();
        var cacheCode = await _cache.GetAsync(phone);
        if (cacheCode != code)
        {
            throw new Exception("Invalid code");
        }

        var user = await _userRepository.GetByPhone(phone);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        user.Verify();
        await _userRepository.Update(user);
    }
}