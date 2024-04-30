namespace IAM.Contracts.Authentication;

public record RegisterRequest(string firstName, string lastName, string phone, string password);