using IAM.Application.Common;

namespace IAM.Application.AuthenticationService;

public class LoginService : ILoginService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Handle(string phone, int code)
    {
        // check if exists
        var existingUser = _userRepository.GetByPhone(phone);
        if (existingUser is null)
        {
            throw new Exception("User not found");
        }
        
        // generate token
        var token = _jwtTokenGenerator.GenerateToken(existingUser);
        
        // return user
        return new AuthenticationResult(existingUser, token);
    }
}