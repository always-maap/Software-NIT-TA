namespace IAM.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Phone,
    bool IsVerified,
    string Token
);