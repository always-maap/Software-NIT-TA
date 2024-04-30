namespace IAM.Contracts.User;

public record UserInfoResponse(
    string Id, 
    string FirstName,
    string LastName,
    string Phone,
    bool IsVerified);