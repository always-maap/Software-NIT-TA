namespace IAM.Application.AuthenticationService;

public interface ILoginService
{
    AuthenticationResult Handle(string phone, string password);
}