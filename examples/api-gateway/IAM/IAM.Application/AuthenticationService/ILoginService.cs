namespace IAM.Application.AuthenticationService;

public interface ILoginService
{
    Task<AuthenticationResult> Handle(string phone, string password);
}