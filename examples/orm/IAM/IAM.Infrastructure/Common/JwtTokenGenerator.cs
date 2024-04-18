using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IAM.Application.Common;
using IAM.Domain;
using Microsoft.IdentityModel.Tokens;

namespace IAM.Infrastructure.Common;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator()
    {
        _jwtSettings = new JwtSettings
        {
            Secret = "85y/7XbloWlrVQuIFLFRyOxH67sL5UPNjJoleFbXfz0=",
            Issuer = "http://localhost:5000",
            Audience = "http://localhost:5000",
            ExpiryMinutes = 60 * 24 * 30
        };
    }

    public string GenerateToken(User user)
    {
        // openssl rand -base64 32
        var signingKey = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtStandardClaims.Sub, user.Id.ToString()),
            new Claim(JwtStandardClaims.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtStandardClaims.PhoneNumber, user.Phone)
        };

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: signingKey,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}