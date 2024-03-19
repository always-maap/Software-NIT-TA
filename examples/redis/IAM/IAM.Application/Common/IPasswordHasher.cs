namespace IAM.Application.Common;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string storedHash, string password);
}