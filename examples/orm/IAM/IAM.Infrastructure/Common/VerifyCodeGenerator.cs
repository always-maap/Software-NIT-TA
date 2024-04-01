using IAM.Application.Common;

namespace IAM.Infrastructure.Common;

public class VerifyCodeGenerator : IVerifyCodeGenerator
{
    public string GenerateCode(string phone)
    {
        var random = new Random();
        return random.Next(10000, 99999).ToString();
    }
}