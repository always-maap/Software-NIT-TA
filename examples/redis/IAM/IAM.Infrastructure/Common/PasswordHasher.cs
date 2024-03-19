using System.Security.Cryptography;
using IAM.Application.Common;

namespace IAM.Infrastructure.Common;

public class PasswordHasher : IPasswordHasher
{
    private const int Iterations = 10000;
    private const int SaltSize = 16;
    private const int HashSize = 20;

    public string HashPassword(string password)
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(HashSize);

        // Combine salt and hash
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
        
        var base64Hash = Convert.ToBase64String(hashBytes);

        return base64Hash;
    }

    public bool VerifyPassword(string storedHash, string password)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);

        // Get the salt
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        // Get stored hash
        byte[] storedHashBytes = new byte[HashSize];
        Array.Copy(hashBytes, SaltSize, storedHashBytes, 0, HashSize);

        // Compare the results
        for (int i = 0; i < HashSize; i++)
        {
            if (storedHashBytes[i] != hash[i])
            {
                return false;
            }
        }

        return true;
    }
}