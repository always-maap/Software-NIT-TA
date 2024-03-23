using IAM.Domain;

namespace IAM.Application.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}