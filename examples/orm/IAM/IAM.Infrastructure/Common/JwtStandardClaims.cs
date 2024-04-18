namespace IAM.Infrastructure.Common;

public static class JwtStandardClaims
{
    // https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
    public const string Sub = "sub";
    public const string Jti = "jti";
    public const string PhoneNumber = "phone_number";
}