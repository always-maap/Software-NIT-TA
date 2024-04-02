namespace IAM.Application.AuthenticationService;

public interface IVerifyService
{
    Task Handle(string code);
}