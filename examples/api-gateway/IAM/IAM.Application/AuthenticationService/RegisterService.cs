using IAM.Application.Common;
using IAM.Domain;

namespace IAM.Application.AuthenticationService;

public class RegisterService : IRegisterService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IVerifyCodeGenerator _verifyCodeGenerator;
    private readonly IVerifyCodeCacheProvider _cache;

    public RegisterService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher, IVerifyCodeGenerator verifyCodeGenerator, IVerifyCodeCacheProvider cache)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
        _verifyCodeGenerator = verifyCodeGenerator;
        _cache = cache;
    }

    public async Task<AuthenticationResult> Handle(string firstName, string lastName, string phone, string password)
    {
        // check if user exists
        if (_userRepository.GetByPhone(phone) is not null)
        {
            throw new Exception("User already exists");
        }

        // create user
        var user = User.Create(firstName, lastName, phone, _passwordHasher.HashPassword(password));

        // add user to database
        _userRepository.Add(user);

        // create token
        var token = _jwtTokenGenerator.GenerateToken(user);

        // store verify code
        var code = _verifyCodeGenerator.GenerateCode(phone);
        await _cache.SetAsync(phone, code, TimeSpan.FromMinutes(5));

        // return newly created user
        return new AuthenticationResult(user, token);
    }
}