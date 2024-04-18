namespace IAM.Application.Common;

public interface ICurrentUser
{
    string GetUserPhone();
    bool IsUserAuthenticated();
}