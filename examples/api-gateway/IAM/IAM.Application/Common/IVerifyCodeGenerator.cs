namespace IAM.Application.Common;

public interface IVerifyCodeGenerator
{
    string GenerateCode(string phone);
}