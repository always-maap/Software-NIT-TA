namespace IAM.Application.AuthenticationService;

public interface IRegisterService
{
    Task<AuthenticationResult> Handle(string firstName, string lastName, string phone, string password);
}