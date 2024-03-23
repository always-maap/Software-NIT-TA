namespace IAM.Infrastructure.Cache.Redis.VerifyCode;

public static class VerifyCodeRedisKeys
{
    public static string GetKey(string phoneNumber) => $"iam:vc:{phoneNumber}";
}