using IAM.Application.Common;

namespace IAM.Application.AuthenticationService;

public class VerifyService : IVerifyService
{
    private readonly IVerifyCodeCacheProvider _cache;
    private readonly IUserRepository _userRepository;

    public VerifyService(IVerifyCodeCacheProvider cache, IUserRepository userRepository)
    {
        _cache = cache;
        _userRepository = userRepository;
    }

    public async Task Handle(string phone, string code)
    {
        var cacheCode = await _cache.GetAsync(phone);
        if (cacheCode != code)
        {
            throw new Exception("Invalid code");
        }
        
        var user = _userRepository.GetByPhone(phone);
        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        user.Verify();
        _userRepository.Update(user);
    }
}