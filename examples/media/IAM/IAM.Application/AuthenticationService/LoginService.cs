using IAM.Application.Common;

namespace IAM.Application.AuthenticationService;

public class LoginService : ILoginService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public LoginService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthenticationResult> Handle(string phone, string password)
    {
        // check if exists
        var existingUser = await _userRepository.GetByPhone(phone);
        if (existingUser is null)
        {
            throw new Exception("User not found");
        }

        // check password
        var isPasswordValid = _passwordHasher.VerifyPassword(existingUser.Password, password);
        if (!isPasswordValid)
        {
            throw new Exception("Invalid password");
        }

        // generate token
        var token = _jwtTokenGenerator.GenerateToken(existingUser);

        // return user
        return new AuthenticationResult(existingUser, token);
    }
}