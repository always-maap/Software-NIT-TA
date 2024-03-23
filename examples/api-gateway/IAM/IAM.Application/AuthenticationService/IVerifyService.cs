namespace IAM.Application.AuthenticationService;

public interface IVerifyService
{
    Task Handle(string phone, string code);
}