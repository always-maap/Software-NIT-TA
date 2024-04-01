namespace IAM.Contracts.Authentication;

public record VerifyRequest(string phone, string code);