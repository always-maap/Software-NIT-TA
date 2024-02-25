using IAM.Application.Common;
using IAM.Domain;

namespace IAM.Application.AuthenticationService;

public class RegisterService : IRegisterService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Handle(string firstName, string lastName, string phone)
    {
        // check if user exists
        if (_userRepository.GetByPhone(phone) is not null)
        {
            throw new Exception("User already exists");
        }
        
        // create user
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone
        };
        
        // add user to database
        _userRepository.Add(user);
        
        // create token
        var token = _jwtTokenGenerator.GenerateToken(user);

        // return newly created user
        return new AuthenticationResult(user, token);
    }
}