using System.Security.Claims;
using IAM.Application.Common;
using IAM.Infrastructure.Common;

namespace IAM.Presentation.Common;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUser(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetUserPhone()
    {
        return _contextAccessor.HttpContext?.User.FindFirstValue(JwtStandardClaims.PhoneNumber) ?? string.Empty;
    }

    public bool IsUserAuthenticated()
    {
        return _contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
}