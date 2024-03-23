namespace IAM.Application.Common;

public interface IVerifyCodeCacheProvider
{
    Task SetAsync(string phoneNumber, string verifyCode, TimeSpan expiration);
    Task<string?> GetAsync(string phoneNumber);
}