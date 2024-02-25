namespace IAM.Application.AuthenticationService;

public interface ILoginService
{
    AuthenticationResult Handle(string phone, int code);
}