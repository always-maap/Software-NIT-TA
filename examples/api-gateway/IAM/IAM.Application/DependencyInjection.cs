using IAM.Application.AuthenticationService;
using IAM.Application.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace IAM.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Authentication services
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IVerifyService, VerifyService>();
        // User services
        services.AddScoped<IUserInfoService, UserInfoService>();
        
        return services;
    }
}